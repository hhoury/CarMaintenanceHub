using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Domain.Entities
{
    public class CarMaintenanceGarage : BaseEntity
    {
        public Guid CarId { get; set; }
        public  Car Car { get; set; }
        public Guid MaintenanceGarageId { get; set; }
        public  MaintenanceGarage MaintenanceGarage { get; set; }
    }
}
