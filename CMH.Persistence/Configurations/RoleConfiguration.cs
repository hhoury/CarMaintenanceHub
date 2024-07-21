using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMH.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole
               {
                   Id =  "0f17bfe8-6a34-418c-bd3b-6ffa9b62535b",
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR",
               },
                new IdentityRole
                {
                    Id = "9ed0a3bd-5e0e-44fb-b555-d1713687f3ce",
                    Name = "Owner",
                    NormalizedName = "OWNER",
                });
        }
    }
}
