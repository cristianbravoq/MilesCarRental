using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Locations.Common;

namespace MilesCarRental.Core.Modules.Locations.GetAvailablesByName;

public record GetAvailablesLocationsByNameQuery(string name) : IRequest<ErrorOr<IReadOnlyList<LocationResponse>>>;