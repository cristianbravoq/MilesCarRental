using System.ComponentModel.DataAnnotations.Schema;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Enumerations;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Domain.Entities.Vechicles;
public class Vehicle : AggregateRoot
{
    //Rules
    public const int MinBrandLength = 3;
    public const int MaxBrandLength = 15;
    public const int MinModelLength = 3;
    public const int MaxModelLength = 5;

    //Properties
    public VehicleId? Id { get; private set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public ClasificationVehicleType Type { get; set; }
    public StateVehicleType State { get; set; }
        
    public LocationId LocationId { get; set; }

    public Location Location { get; set; } 


    public Vehicle(
            VehicleId id,
            string brand,
            string model,
            ClasificationVehicleType type,
            StateVehicleType state
            )
    {
        //Enforce invariants
        Id = id;
        Brand = brand;
        Model = model;
        Type = type;
        State = state;
    }

    private Vehicle()
    {

    }
}