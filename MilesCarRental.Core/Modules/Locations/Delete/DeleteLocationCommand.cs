using ErrorOr;
using MediatR;

namespace MilesCarRental.Core.Modules.Locations.Delete;

public record DeleteLocationCommand(Guid Id) : IRequest<ErrorOr<Unit>>;