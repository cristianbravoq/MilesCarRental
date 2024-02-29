using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Locations.Common;
using MilesCarRental.Domain.DomainErrors;
using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Core.Modules.Locations.GetAllAvailables;

internal sealed class GetAllAvailablesLocationsQueryHandler : IRequestHandler<GetAllAvailablesLocationsQuery, ErrorOr<IReadOnlyList<LocationResponse>>>
{
    private readonly ILocationRepository _locationRepository;

    public GetAllAvailablesLocationsQueryHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<LocationResponse>>> Handle(GetAllAvailablesLocationsQuery query, CancellationToken cancellationToken)
    {
        if (await _locationRepository.GetAllAvailablesAsync() is not List<Location> locations)
            return ErrorsLocation.NotFound;

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