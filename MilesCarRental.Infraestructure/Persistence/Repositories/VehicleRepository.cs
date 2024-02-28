using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Enumerations;
using MilesCarRental.Infraestructure.Utils;
using NetTopologySuite.Geometries;

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

    public async Task<List<Vehicle>> GetAvailableVehiclesByLocationAsync(VehiclesAvailablesByLocationRequest ubications)
    {
        var clientLocation = new Point(ubications.LongitudeUser, ubications.LatitudeUser) { SRID = 4326 };
        var maxAllowedDistanceByKilometres = 1000;

        // Convert maximum distance from kilometres to metres
        var maxDistanceInMeters = maxAllowedDistanceByKilometres * 1000;

        return await _context.Vehicles
            .Include(v => v.Location)
            .Where(v => v.State == StateVehicleType.Available)
            .Where(v => v.LocationId == new LocationId(ubications.locationSelectedId) || v.Location.Ubication.Distance(clientLocation) <= maxDistanceInMeters)
            .ToListAsync();
    }
}

//.Where(v => v.LocationId == new LocationId(ubications.locationSelectedId) && v.State == StateVehicleType.Available)
//         
// .Where(v => DistanceCalculator.CalculateDistance(v.Location.Longitude, v.Location.Longitude, clientLocation) <= maxDistanceInMeters)
                    