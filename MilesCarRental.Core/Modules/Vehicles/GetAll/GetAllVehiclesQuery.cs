using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Vehicles.Common;

namespace MilesCarRental.Core.Modules.Vehicles.GetAll;

public record GetAllVehiclesQuery() : IRequest<ErrorOr<IReadOnlyList<VehiclesResponse>>>;