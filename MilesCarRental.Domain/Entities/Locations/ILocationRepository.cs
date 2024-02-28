namespace MilesCarRental.Domain.Entities.Locations;

public interface ILocationRepository
{
    Task<List<Location>> GetAll();
    Task<Location> GetByIdAsync(LocationId id);
    Task<Location> ExistsAsync(LocationId id);
    Task<List<Location>> GetByNameAvailablesAsync(string name);
    void Add(Location location);
    void Update(Location id);
    void Delete(Location location);
}           