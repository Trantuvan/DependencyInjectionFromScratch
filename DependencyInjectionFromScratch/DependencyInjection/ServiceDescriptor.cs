namespace DependencyInjectionFromScratch.DependencyInjection;

public class ServiceDescriptor
{
    public Type Type { get; set; } = default!;
    public object Implementation { get; set; } = default!;
}
