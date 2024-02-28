using ErrorOr;

namespace MilesCarRental.Domain.DomainErrors;

public static partial class ErrorsLocation
{
    public static Error AddressWithBadFormat =>
        Error.Validation("Customer.Address", "Address is not valid.");
}