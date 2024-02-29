using ErrorOr;
using MediatR;

namespace MilesCarRental.Core.Modules.Vehicles.Delete;

public record DeleteVehiclesCommand(Guid Id) : IRequest<ErrorOr<Unit>>;