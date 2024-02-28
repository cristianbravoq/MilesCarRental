using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Infraestructure.Persistence.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async void Add(Location location) => await _context.Locations.AddAsync(location);

    public void Delete(Location location)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Location>> GetByNameAvailablesAsync(string name) =>
        await _context.Locations
            .Where(location => location.Name!.Contains(name))
            .ToListAsync();

    public void Update(Location location)
    {
        throw new NotImplementedException();
    }

    public Task<Location> ExistsAsync(LocationId id)
    {
        throw new NotImplementedException();
    }

    public Task<Location> GetByIdAsync(LocationId id)
    {
        throw new NotImplementedException();
    }
}