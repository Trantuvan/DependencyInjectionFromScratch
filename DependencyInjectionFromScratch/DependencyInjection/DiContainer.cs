namespace DependencyInjectionFromScratch.DependencyInjection;

public class DiContainer
{
    private readonly List<ServiceDescriptor> _serviceDescriptors;

    public DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }
    public T GetService<T>()
    {
        var descriptor = _serviceDescriptors
                   .FirstOrDefault(service => service.ServiceType == typeof(T));

        if (descriptor is null)
        {
            throw new Exception($"Service of type {typeof(T).Name} isn't register");
        }

        // for concrete impl type
        if (descriptor.Implementation is not null)
        {
            return (T)descriptor.Implementation;
        }

        // for generic register | use System.Activator to create new instance
        // for impl Type
        var implementation = (T)Activator.CreateInstance(descriptor.ServiceType);

        // Singleton overload Impl to return impl reference
        if (descriptor.Lifetime.Equals(ServiceLifetime.Singleton))
        {
            descriptor.Implementation = implementation;
        }

        return implementation;
    }
}
