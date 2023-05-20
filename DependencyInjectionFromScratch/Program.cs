using DependencyInjectionFromScratch.DependencyInjection;

namespace DependencyInjectionFromScratch;

class Program
{
    static void Main(string[] args)
    {
        var services = new DiServiceCollection();

        //services.RegisterTransient<RandomGuidGenerator>();
        //services.RegisterSingleton(new RandomGuidGenerator());

        services.RegisterSingleton<ISomeService, SomeServiceOne>();
        services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();

        var container = services.GenerateContainer();

        //Get the RandomGuid | the 2nd request should return the same reference as the 1st request
        var serviceFirst = container.GetService<ISomeService>();
        var serviceSecond = container.GetService<ISomeService>();

        serviceFirst.PrintSomething();
        serviceSecond.PrintSomething();
    }
}