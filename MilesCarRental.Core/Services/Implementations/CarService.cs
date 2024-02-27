using MilesCarRental.Domain.Entities.Cars;
using MilesCarRental.Core.Services.Contracts;

namespace MilesCarRental.Core.Services.Implementations;

public class CarService : ICarService
{
    public Task<IEnumerable<Car>> GetCarsByLocation(string location)
    {
        throw new NotImplementedException();
    }
}