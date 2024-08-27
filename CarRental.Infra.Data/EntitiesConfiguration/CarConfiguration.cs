using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infra.Data.EntitiesConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.CarId);
            builder.Property(x => x.CarModel).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Manufacturer).HasMaxLength(25).IsRequired();
            builder.Property(x => x.CarType).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Plate).HasMaxLength(15).IsRequired();
            builder.Property(x => x.CarYear).IsRequired();
            builder.Property(x => x.Color).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Mileage).HasPrecision(7).IsRequired();
            builder.Property(x => x.RentPrice).HasPrecision(10, 2).IsRequired();
        }
    }
}
