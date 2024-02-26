namespace MilesCarRental.Contracts.Locations;

public record CreateLocationRequest
{
    public int Capacity { get; init;}
    public bool Available { get; init; }
    public string? Name { get; init; }
    public DateTime StartDateTime { get; init; }
}