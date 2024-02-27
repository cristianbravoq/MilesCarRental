using MilesCarRental.Domain.Enumerations;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Domain.Entities.Cars;
public class Car : AggregateRoot
{
    //Rules
    public const int MinBrandLength = 3;
    public const int MaxBrandLength = 15;
    public const int MinModelLength = 3;
    public const int MaxModelLength = 5;

    //Properties
    public CarId Id { get; private set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Location { get; set; }
    public ClasificationCarType Type { get; set; }
    public StateCarType State { get; set; }

    public Car(
            CarId id,
            string brand,
            string model,
            string location,
            ClasificationCarType type,
            StateCarType state)
    {
        //Enforce invariants
        Id = id;
        Brand = brand;
        Model = model;
        Location = location;
        Type = type;
        State = state;
    }

    private Car()
    {

    }

}
