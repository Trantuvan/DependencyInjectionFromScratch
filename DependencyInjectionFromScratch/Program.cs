using DependencyInjectionFromScratch.DependencyInjection;

namespace DependencyInjectionFromScratch;

class Program
{
    static void Main(string[] args)
    {
        var services = new DiServiceCollection();

        services.RegisterSingleton<RandomGuidGenerator>();
        services.RegisterSingleton(new RandomGuidGenerator());

        var container = services.GenerateContainer();

        //Get the RandomGuid | the 2nd request should return the same reference as the 1st request
        var serviceFirst = container.GetService<RandomGuidGenerator>();
        var serviceSecond = container.GetService<RandomGuidGenerator>();

        Console.WriteLine(serviceFirst.RandomGuid);
        Console.WriteLine(serviceSecond.RandomGuid);
    }
}