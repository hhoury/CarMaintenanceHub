using CMH.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMH.Persistence.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id);
            modelBuilder.Property(c => c.Make).IsRequired();
            modelBuilder.Property(c => c.Year).IsRequired();
            modelBuilder.Property(c => c.Model).IsRequired();
            modelBuilder.HasOne(c => c.User).WithMany(c => c.Cars).HasForeignKey(c => c.UserId);
            modelBuilder.HasMany(c => c.CarMaintenanceGarages).WithOne(cmg => cmg.Car).HasForeignKey(c => c.CarId);
       
        }
    }
}
