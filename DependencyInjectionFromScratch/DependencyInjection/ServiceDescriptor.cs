namespace DependencyInjectionFromScratch.DependencyInjection;

public class ServiceDescriptor
{
    public Type ServiceType { get; } = default!;
    public object Implementation { get; internal set; } = default!;
    public ServiceLifetime Lifetime { get; }
    public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
    {
        ServiceType = implementation.GetType();
        Implementation = implementation;
        Lifetime = lifetime;
    }
    public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
    {
        ServiceType = serviceType;
        Lifetime = lifetime;
    }
}
