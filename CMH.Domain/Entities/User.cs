using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
