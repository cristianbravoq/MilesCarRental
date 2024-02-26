using MilesCarRental.Core.Enumerations;
using ErrorOr;

namespace MilesCarRental.Core.Entities;
public class Car
{
    //Rules
    public const int MinBrandLength = 3;
    public const int MaxBrandLength = 15;
    public const int MinModelLength = 3;
    public const int MaxModelLength = 5;

    //Properties
    public Guid Id { get; }
    public string Brand { get; }
    public string Model { get; }
    public string Location { get; }
    public ClasificationCarType Type { get; }
    public StateCarType State { get; }

    private Car(
            Guid id,
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

    //public static ErrorOr<Car> Create(
    //    string brand,
    //    string model,
    //    string location,
    //    StateCarType state,
    //    Guid? id = null)
    //{
    //    List<Error> errors = new();

    //    if (brand.Length is MinBrandLength or > MaxBrandLength)
    //    {
    //        errors.Add(errors.Car.InvalidName
    //    }
    //}
}
