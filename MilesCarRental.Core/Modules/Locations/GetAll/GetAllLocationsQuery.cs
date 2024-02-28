using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Locations.Common;

namespace MilesCarRental.Core.Modules.Locations.GetAll;

public record GetAllLocationsQuery() : IRequest<ErrorOr<IReadOnlyList<LocationResponse>>>;