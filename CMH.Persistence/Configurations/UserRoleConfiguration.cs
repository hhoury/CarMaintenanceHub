using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMH.Persistence.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "0f17bfe8-6a34-418c-bd3b-6ffa9b62535b",
                   UserId = "0b72b30a-6053-42b4-99c4-ceebd0cca368"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "9ed0a3bd-5e0e-44fb-b555-d1713687f3ce",
                   UserId = "1"
               }
           );
        }
    }
}
