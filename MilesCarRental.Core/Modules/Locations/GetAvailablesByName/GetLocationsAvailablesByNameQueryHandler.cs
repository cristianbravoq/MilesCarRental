using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Locations.Common;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Core.Modules.Locations.GetAvailablesByName;

internal sealed class GetAvailablesLocationsByNameQueryHandler : IRequestHandler<GetAvailablesLocationsByNameQuery, ErrorOr<IReadOnlyList<LocationResponse>>>
{
    private readonly ILocationRepository _locationRepository;

    public GetAvailablesLocationsByNameQueryHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<LocationResponse>>> Handle(GetAvailablesLocationsByNameQuery query, CancellationToken cancellationToken)
    {
        if (await _locationRepository.GetByNameAvailablesAsync(query.name) is not List<Location> locations)
        {
            return Error.NotFound("Locations.NotFound", "The locations with the provide name was not found.");
        }

        return locations.Select(
            location => new LocationResponse(
                location.Id!.value,
                location.Capacity,
                location.Available,
                location.Name!,
                location.Address,
                location.Latitude,
                location.Longitude
            )
        ).ToList();
    }
}