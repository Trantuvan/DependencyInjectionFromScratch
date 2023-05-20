namespace DependencyInjectionFromScratch.DependencyInjection;

public class ServiceDescriptor
{
    public Type ServiceType { get; } = default!;
    public object Implementation { get; } = default!;
    public ServiceLifetime Lifetime { get; }
    public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
    {
        ServiceType = implementation.GetType();
        Implementation = implementation;
        Lifetime = lifetime;
    }
}
