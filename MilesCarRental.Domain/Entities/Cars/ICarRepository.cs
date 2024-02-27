namespace MilesCarRental.Domain.Entities.Cars;

public interface ICarRepository
{
    Task<List<Car>> GetAll();
    Task<Car?> GetByIdAsync(CarId id);
    Task<Car> ExistsAsync(CarId id);
    void Add(Car car);
    void Update(Car car);
    void Delete(Car car);
}