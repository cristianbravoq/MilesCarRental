namespace MilesCarRental.Domain.Entities.Locations;

public class Location
{
    //Rules
    public const int MinNameLength = 3;
    public const int MaxNameLength = 15;
    public const int MaxCapacityLength = 5;

    //Properties
    public LocationId? Id { get; private set; }
    public int Capacity { get; }
    public bool Available { get; }
    public string? Name { get; }

    public Location(
            LocationId id,
            int capacity,
            bool available,
            string name)
    {   
        Id = id;
        Capacity = capacity;
        Available = available;
        Name = name;
    }

    private Location()
    {
        
    }
}