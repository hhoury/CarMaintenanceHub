using CMH.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Persistence.Configurations
{
    public class MaintenanceGarageConfiguration : IEntityTypeConfiguration<MaintenanceGarage>
    {
        public void Configure(EntityTypeBuilder<MaintenanceGarage> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property(mg => mg.Name).IsRequired();
            modelBuilder.HasMany(mg => mg.CarMaintenanceGarages).WithOne(cmg => cmg.MaintenanceGarage).HasForeignKey(cmg => cmg.MaintenanceGarageId);
        }
    }
}
