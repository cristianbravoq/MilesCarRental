using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.ValueObjects;
using NetTopologySuite.Geometries;

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
    public Point Ubication { get; }

    public List<Vehicle> Vehicles { get; set; }

    public Location(
            LocationId id,
            int capacity,
            bool available,
            string name,
            Address address,
            double latitude,
            double longitude,
            Point ubication
        )
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentException("Invalid longitude value", nameof(longitude));

        if (longitude < -180 || longitude > 180)
            throw new ArgumentException("Invalid longitude value", nameof(longitude));

        Id = id;
        Capacity = capacity;
        Available = available;
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        Ubication = new Point(longitude, latitude) { SRID = 4326 };
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
            longitude,
            new Point(longitude, latitude) { SRID = 4326 }
            );
    }
}