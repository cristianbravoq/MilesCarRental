namespace MilesCarRental.Domain.Entities.Locations;

public class Location
{
    //Rules
    public const int MinNameLength = 3;
    public const int MaxNameLength = 15;
    public const int MaxCapacityLength = 5;

    //Properties
    public Guid Id { get; }
    public int Capacity { get; }
    public bool Available { get; }
    public string? Name { get; }
}