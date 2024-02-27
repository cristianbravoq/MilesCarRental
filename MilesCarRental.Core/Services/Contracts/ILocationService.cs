using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Domain.Entities.Locations;

public interface ILocationService{
    Task<IEnumerable<Location>> GetLocationsByAvailability();
}