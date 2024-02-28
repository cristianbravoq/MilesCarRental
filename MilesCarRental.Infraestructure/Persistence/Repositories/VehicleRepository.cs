using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Vechicles;

namespace MilesCarRental.Infraestructure.Persistence.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Vehicle vehicle) => _context.Vehicles.Add(vehicle);
    
    public void Delete(Vehicle vehicle) => _context.Vehicles.Remove(vehicle);
    
    public void Update(Vehicle vehicle) => _context.Vehicles.Update(vehicle);
    
    public async Task<bool> ExistsAsync(VehicleId id) => await _context.Vehicles.AnyAsync(vehicle => vehicle.Id == id);
    
    public async Task<Vehicle?> GetByIdAsync(VehicleId id) => await _context.Vehicles
        .Include(v => v.Location)
        .SingleOrDefaultAsync(c => c.Id == id);
    
    public async Task<List<Vehicle>> GetAll() => await _context.Vehicles
        .Include(v => v.Location)
        .ToListAsync();
}