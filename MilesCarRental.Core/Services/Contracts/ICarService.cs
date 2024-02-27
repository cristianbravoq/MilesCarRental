using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Core.Services.Contracts;

public interface ICarService {
    Task<IEnumerable<Car>> GetCarsByLocation(string location);
}