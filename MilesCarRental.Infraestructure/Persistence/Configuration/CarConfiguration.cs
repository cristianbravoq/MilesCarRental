using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Entities.Cars;

namespace MilesCarRental.Infraestructure.Persistence.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasConversion(
            carId => carId.Value,
            value => new CarId(value));

        builder.Property(c => c.Brand).HasMaxLength(10);
        builder.Property(c => c.Model).HasMaxLength(4);
        builder.Property(c => c.Location).HasMaxLength(50);
        // No establezcer límite de longitud para las propiedades de tipo enumerado
        builder.Property(c => c.Type);
        builder.Property(c => c.State);
    }
}