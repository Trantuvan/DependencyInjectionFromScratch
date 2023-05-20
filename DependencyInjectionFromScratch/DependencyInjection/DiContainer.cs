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

        if (descriptor.Implementation is null)
        {
            return default!;
        }

        return (T)descriptor.Implementation;
    }

}
