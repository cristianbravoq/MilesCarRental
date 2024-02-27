using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Infraestructure.Persistence.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            locationId => locationId!.value,
            value => new LocationId(value));

        builder.Property(c => c.Capacity);
        builder.Property(c => c.Available);
        builder.Property(c => c.Name);
    }
}