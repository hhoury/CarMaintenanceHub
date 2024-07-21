using CMH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Application.Models
{
    public class Owner
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<Car> Cars{ get; set; }
    }
}
