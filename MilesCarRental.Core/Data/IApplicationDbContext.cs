using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Vechicles;
using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Core.Data;

public interface IApplicationDbContext
{
    DbSet<Vehicle> Vehicles { get; set; }
    DbSet<Location> Locations { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}