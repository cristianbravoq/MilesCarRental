using ErrorOr;
using MediatR;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Enumerations;

namespace MilesCarRental.Core.Modules.Vehicles.Update;

public record UpdateVehicleCommand(
    Guid Id,
    string Brand,
    string Model,
    string Location,
    ClasificationVehicleType Type,
    StateVehicleType State,
    LocationId LocationId
): IRequest<ErrorOr<Unit>>;