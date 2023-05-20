using DependencyInjectionFromScratch.DependencyInjection;

namespace DependencyInjectionFromScratch;

class Program
{
    static void Main(string[] args)
    {
        var services = new DiServiceCollection();

        services.RegisterSingleton<RandomGuidGenerator>();

        var container = services.GenerateContainer();

        var service = container.GetService<RandomGuidGenerator>();
    }
}