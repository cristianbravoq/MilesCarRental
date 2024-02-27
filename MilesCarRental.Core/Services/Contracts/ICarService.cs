using MilesCarRental.Domain.Entities.Cars;

namespace MilesCarRental.Core.Services.Contracts;

public interface ICarService {
    Task<IEnumerable<Car>> GetCarsByLocation(string location);
}