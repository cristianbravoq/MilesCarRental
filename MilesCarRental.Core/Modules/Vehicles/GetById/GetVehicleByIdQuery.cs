using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Vehicles.Common;

namespace MilesCarRental.Core.Modules.Vehicles.GetById;

public record GetVehicleByIdQuery(Guid Id) : IRequest<ErrorOr<VehiclesResponse>>;