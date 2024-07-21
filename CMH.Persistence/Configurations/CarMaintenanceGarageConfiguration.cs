using CMH.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMH.Persistence.Configurations
{
    public class CarMaintenanceGarageConfiguration : IEntityTypeConfiguration<CarMaintenanceGarage>
    {
        public void Configure(EntityTypeBuilder<CarMaintenanceGarage> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.HasOne(c=> c.Car).WithMany(cmg => cmg.CarMaintenanceGarages ).HasForeignKey(cmg => cmg.CarId);
            modelBuilder.HasOne(mg=> mg.MaintenanceGarage).WithMany(cmg => cmg.CarMaintenanceGarages ).HasForeignKey(cmg => cmg.MaintenanceGarageId);

        }
    }
}
