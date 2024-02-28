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

    public async void Add(Vehicle vehicle) => await _context.Vehicles.AddAsync(vehicle);


    public void Delete(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public Task<Vehicle> ExistsAsync(VehicleId id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Vehicle>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Vehicle?> GetByIdAsync(VehicleId id) => await _context.Vehicles.SingleOrDefaultAsync(vehicle => vehicle.Id == id);

    public void Update(Vehicle vehicle)
    {
        throw new NotImplementedException();
    }
}