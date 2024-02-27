using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Core.Services.Contracts;

namespace MilesCarRental.Core.Services.Implementations;

public class LocationService : ILocationService
{
    public Task<IEnumerable<Location>> GetLocationsByAvailability()
    {
        throw new NotImplementedException();
    }
}