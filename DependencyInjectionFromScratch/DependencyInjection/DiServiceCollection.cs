namespace DependencyInjectionFromScratch.DependencyInjection;

public class DiServiceCollection
{
    private readonly List<ServiceDescriptor> _serviceDescriptors = new();
    public void RegisterSingleton<TService>()
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
    }

    public void RegisterSingleton<TService>(TService implementation)
    {
        if (implementation is null)
        {
            throw new Exception("cannot register null implementation");
        }
        _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
    }

    public void RegisterTransient<TService>()
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
    }


    public DiContainer GenerateContainer()
    {
        return new DiContainer(_serviceDescriptors);
    }
}
