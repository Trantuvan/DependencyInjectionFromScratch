namespace DependencyInjectionFromScratch.DependencyInjection;

public class DiContainer
{
    private readonly List<ServiceDescriptor> _serviceDescriptors;

    public DiContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }

    public object GetService(Type serviceType)
    {
        var descriptor = _serviceDescriptors
           .FirstOrDefault(service => service.ServiceType == serviceType);

        if (descriptor is null)
        {
            throw new Exception($"Service of type {serviceType.Name} isn't register");
        }

        // for concrete impl type
        if (descriptor.Implementation is not null)
        {
            return descriptor.Implementation;
        }

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsAbstract || actualType.IsInterface)
        {
            throw new Exception("Cannot instantiate abstract classes or interfaces");
        }

        var constructorInfo = actualType.GetConstructors().First();

        var parameters = constructorInfo.GetParameters()
                 .Select(p => GetService(p.ParameterType)).ToArray();

        // for generic register | use System.Activator to create new instance
        // for impl Type
        var implementation = Activator.CreateInstance(actualType, parameters);

        // Singleton overload Impl to return impl reference
        if (descriptor.Lifetime.Equals(ServiceLifetime.Singleton))
        {
            descriptor.Implementation = implementation;
        }

        return implementation;
    }
    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }
}
