using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Enumerations;

namespace MilesCarRental.Core.Modules.Vehicles.Update;

public record UpdateVehicleCommand(
    Guid Id,
    string Brand,
    string Model,
    string Location,
    ClasificationVehicleType Type,
    StateVehicleType State,
    Guid LocationId
): IRequest<ErrorOr<Unit>>;