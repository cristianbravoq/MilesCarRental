using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities.Vechicles;

namespace MilesCarRental.Infraestructure.Persistence.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            vehicleId => vehicleId!.value,
            value => new VehicleId(value));

        builder.Property(v => v.Brand).HasMaxLength(15);
        builder.Property(v => v.Model).HasMaxLength(5);

        builder.Property(c => c.Type);
        builder.Property(c => c.State);

        builder.Property(v => v.LocationId).IsRequired();
        builder.HasOne(v => v.Location)
               .WithMany(l => l.Vehicles)
               .HasForeignKey(v => v.LocationId);
    }
}