using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Vehicles.Common;
using MilesCarRental.Domain.Entities.Vechicles;

namespace MilesCarRental.Core.Modules.Vehicles.GetById;

public record GetAvailableVehiclesByUbicationQuery(
    Guid locationSelectedId,
    double LatitudeUser,
    double LongitudeUser
) : IRequest<ErrorOr<IReadOnlyList<VehiclesResponse>>>;