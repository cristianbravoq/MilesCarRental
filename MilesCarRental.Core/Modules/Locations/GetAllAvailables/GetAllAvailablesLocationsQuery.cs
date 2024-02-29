using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Locations.Common;

namespace MilesCarRental.Core.Modules.Locations.GetAllAvailables;

public record GetAllAvailablesLocationsQuery() : IRequest<ErrorOr<IReadOnlyList<LocationResponse>>>;