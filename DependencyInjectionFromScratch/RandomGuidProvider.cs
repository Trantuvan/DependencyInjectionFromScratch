namespace DependencyInjectionFromScratch;

public class RandomGuidProvider : IRandomGuidProvider
{
    public Guid RandomGuid { get; } = Guid.NewGuid();
}

public interface IRandomGuidProvider
{
    Guid RandomGuid { get; }
}
