using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Domain.Entities
{
    public class MaintenanceGarage : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CarMaintenanceGarage> CarMaintenanceGarages { get; set; }
    }
}
