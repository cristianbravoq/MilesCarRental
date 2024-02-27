namespace MilesCarRental.Domain.Entities.Locations;

public interface ILocationRepository
{
    Task<List<Location>> GetAll();
    Task<Location> GetByIdAsync(LocationId id);
    Task<List<Location>> GetByNameAvailablesAsync(string name);
    void Add(Location location);
    void Update(Location location);
    void Delete(Location location);
}