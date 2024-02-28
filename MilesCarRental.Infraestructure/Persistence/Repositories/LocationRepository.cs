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
    
    public async Task<List<Location>> GetByNameAvailablesAsync(string name) =>
        await _context.Locations
            .Where(location => location.Name!.Contains(name))
            .ToListAsync();
    public void Add(Location location) => _context.Locations.Add(location);
    public void Delete(Location location) => _context.Locations.Remove(location);
    public void Update(Location location) => _context.Locations.Update(location);
    public async Task<bool> ExistsAsync(LocationId id) => await _context.Locations.AnyAsync(location => location.Id == id);
    public async Task<Location?> GetByIdAsync(LocationId id) => await _context.Locations.SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Location>> GetAll() => await _context.Locations.ToListAsync();
}