using ErrorOr;

namespace MilesCarRental.Domain.DomainErrors;

public static partial class ErrorsLocation
{
    public static Error IdProvidedNotFound => Error.NotFound(
        code: "Location.NotFound",
        description: "The location with the provide Id was not found." );

    public static Error AddressWithBadFormat => Error.Validation(
        code: "Location.Address",
        description: "Address is not valid.");

    public static Error InvalidLatitude(double latitude) => Error.Validation(
        code: "Location.InvalidLatitude",
        description: $"Latitude must be between -90 and 90 degrees. Received value: {latitude}");

    public static Error InvalidLongitude(double longitude) => Error.Validation(
        code: "Location.InvalidLongitude",
        description: $"Longitude must be between -180 and 180 degrees. Received value: {longitude}");

    public static Error NameProvidedNotFound => Error.NotFound(
        code: "Location.NotFound",
        description: "The name with the provide was not found."
    );

    public static Error NotFound => Error.NotFound(
        code: "Location.NotFound",
        description: "Not found items"
    );
}