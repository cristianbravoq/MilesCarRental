using MediatR;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Core.Data;
using MilesCarRental.Domain.Entities.Cars;
using MilesCarRental.Domain.Entities.Locations;
using MilesCarRental.Domain.Primitives;

namespace MilesCarRental.Infraestructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base (options)
    {
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                            .Select(e => e.Entity)
                            .Where(e => e.GetDomainEvents().Any())
                            .SelectMany(e => e.GetDomainEvents());

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        Console.WriteLine("Bandera de app context");

        return result;
    }
}