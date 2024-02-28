using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Domain.Entities.Locations;

public class Location
{
    public LocationId? Id { get; private set; }
    public int Capacity { get; }
    public bool Available { get; }
    public string? Name { get; }
    public Address Address { get; private set; }
    public double Latitude { get; }
    public double Longitude { get; }

    public List<Vehicle> Vehicles { get; set; }

    public Location(
            LocationId id,
            int capacity,
            bool available,
            string name,
            Address address,
            double latitude,
            double longitude
        )
    {
        Id = id;
        Capacity = capacity;
        Available = available;
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    private Location()
    {

    }

    public static Location UpdateLocation(
            Guid id,
            int capacity,
            bool available,
            string name,
            Address address,
            double latitude,
            double longitude)
    {
        return new Location(
            new LocationId(id), 
            capacity, 
            available, 
            name, 
            address, 
            latitude, 
            longitude);
    }
}