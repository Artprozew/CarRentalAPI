using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infra.Data.EntitiesConfiguration
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(x => x.RentalId);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.CarId).IsRequired();
            builder.Property(x => x.RentalDate).IsRequired();
            builder.Property(x => x.ReturnDate).IsRequired();
            builder.Property(x => x.HasReturned).IsRequired();
            builder.Property(x => x.TotalPrice).HasPrecision(10, 2).IsRequired();

            builder.HasOne(x => x.Customer).WithMany(x => x.Rentals)
                .HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Car).WithMany(x => x.Rentals)
                .HasForeignKey(x => x.CarId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
