using ErrorOr;
using MilesCarRental.Domain.Entities.Vechicles;

namespace MilesCarRental.Domain.DomainErrors;

public static partial class ErrorsVechicles
{
    public static Error InvalidBrand => Error.Validation(
       code: "Vehicle.InvalidBrand",
       description: $"Vehicle name must be at least {Vehicle.MinBrandLength}" +
           $" characters long and at most {Vehicle.MaxBrandLength} characters long.");

    public static Error InvalidModel => Error.Validation(
       code: "Vehicle.InvalidModel",
       description: $"Vehicle model must be at least {Vehicle.MinModelLength}" +
           $" characters long and at most {Vehicle.MaxModelLength} characters long.");

    public static Error NotFound => Error.NotFound(
        code: "Vehicle.NotFound",
        description: "Vehicle not found");
}