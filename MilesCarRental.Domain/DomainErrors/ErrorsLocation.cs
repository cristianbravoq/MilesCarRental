using ErrorOr;

namespace MilesCarRental.Domain.DomainErrors;

public static partial class ErrorsLocation
{
    public static Error AddressWithBadFormat =>
        Error.Validation("Location.Address", "Address is not valid.");
}