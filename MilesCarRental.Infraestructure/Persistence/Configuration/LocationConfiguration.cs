using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities.Locations;

namespace MilesCarRental.Infraestructure.Persistence.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Domain.Entities.Locations.Location>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Locations.Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            locationId => locationId!.value,
            value => new LocationId(value));

        builder.Property(c => c.Capacity);
        builder.Property(c => c.Available);
        builder.Property(c => c.Name)
            .HasMaxLength(50);

        builder.OwnsOne(c => c.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country).HasMaxLength(3);
            addressBuilder.Property(a => a.Line1).HasMaxLength(20);
            addressBuilder.Property(a => a.Line2).HasMaxLength(20);
            addressBuilder.Property(a => a.City).HasMaxLength(40);
            addressBuilder.Property(a => a.State).HasMaxLength(40);
            addressBuilder.Property(a => a.ZipCode).HasMaxLength(10);
        });
        
        builder.Property(l => l.Ubication)
                .HasConversion(
                    p => p,
                    p => p);

        builder.Property(c => c.Latitude);
        builder.Property(c => c.Longitude);
    }
}