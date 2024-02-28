using ErrorOr;
using MediatR;
using MilesCarRental.Core.Modules.Locations.Common;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.ValueObjects;

namespace MilesCarRental.Core.Modules.Locations.GetAll;

internal sealed class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, ErrorOr<IReadOnlyList<LocationResponse>>>
{
    private readonly ILocationRepository _locationRepository;

    public GetAllLocationsQueryHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    public async Task<ErrorOr<IReadOnlyList<LocationResponse>>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Location> locations = await _locationRepository.GetAll();

        return locations.Select(
            location => new LocationResponse(
                location.Id!.value,
                location.Capacity,
                location.Available,
                location.Name!,
                location.Address,               
                location.Latitude,
                location.Longitude)
        ).ToList();
    }
}