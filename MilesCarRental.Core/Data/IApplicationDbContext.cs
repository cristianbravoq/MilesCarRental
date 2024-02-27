using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Cars;
using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Core.Data;

public interface IApplicationDbContext
{
    DbSet<Car> Cars { get; set; }
    DbSet<Location> Locations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}