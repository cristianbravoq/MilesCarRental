using MilesCarRental.Core.Entities;

namespace MilesCarRental.Core.Services.Contracts;

public interface ILocationService{
    Task<IEnumerable<Location>> GetLocationsByAvailability();
}