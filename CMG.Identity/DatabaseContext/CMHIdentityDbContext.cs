using CMH.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Identity.DatabaseContext
{
    public class CMHIdentityDbContext : IdentityDbContext<User>
    {
        public CMHIdentityDbContext(DbContextOptions<CMHIdentityDbContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(CMHIdentityDbContext).Assembly);
        }
    }
}
