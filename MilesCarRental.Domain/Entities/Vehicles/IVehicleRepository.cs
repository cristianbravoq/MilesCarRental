namespace MilesCarRental.Domain.Entities.Vechicles;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetAll();
    Task<Vehicle?> GetByIdAsync(VehicleId id);
    Task<List<Vehicle>> GetAvailableVehiclesByLocationAsync(VehiclesAvailablesByLocationRequest ubications);
    Task<bool> ExistsAsync(VehicleId id);
    void Add(Vehicle vehicle);
    void Update(Vehicle vehicle);
    void Delete(Vehicle vehicle);
}