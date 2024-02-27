using MilesCarRental.Domain.Entities.Cars;
using ErrorOr;

namespace MilesCarRental.API.ServiceErrors
{
    public static class Errors
    {
        public static class Cars
        {
            public static Error InvalidBrand => Error.Validation(
               code: "Car.InvalidBrand",
               description: $"Car name must be at least {Car.MinBrandLength}" +
                   $" characters long and at most {Car.MaxBrandLength} characters long.");

            public static Error InvalidModel => Error.Validation(
               code: "Car.InvalidModel",
               description: $"Car model must be at least {Car.MinModelLength}" +
                   $" characters long and at most {Car.MaxModelLength} characters long.");

            public static Error NotFound => Error.NotFound(
                code: "Car.NotFound",
                description: "Car not found");
        }
    }
}