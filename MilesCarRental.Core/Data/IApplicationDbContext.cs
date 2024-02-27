using Microsoft.EntityFrameworkCore;
using MilesCarRental.Domain.Entities.Cars;

namespace MilesCarRental.Core.Data;

public interface IApplicationDbContext
{
    DbSet<Car> Cars { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}