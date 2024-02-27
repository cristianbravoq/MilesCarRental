using ErrorOr;
using MediatR;

namespace MilesCarRental.Core.Modules.Locations.Create;

public record CreateLocationCommand(
        int Capacity,
        bool Available,
        string Name
) : IRequest<ErrorOr<Unit>>;