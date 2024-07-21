using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public  string UserId { get; set; }
        public  User User { get; set; }
        public ICollection<CarMaintenanceGarage> CarMaintenanceGarages { get; set; }
    }
}
