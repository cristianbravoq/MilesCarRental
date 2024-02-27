using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Cars;

namespace MilesCarRental.Infraestructure.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async void Add(Car car) => await _context.Cars.AddAsync(car);


    public void Delete(Car car)
    {
        throw new NotImplementedException();
    }

    public Task<Car> ExistsAsync(CarId id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Car>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Car?> GetByIdAsync(CarId id) => await _context.Cars.SingleOrDefaultAsync(car => car.Id == id);

    public void Update(Car car)
    {
        throw new NotImplementedException();
    }
}