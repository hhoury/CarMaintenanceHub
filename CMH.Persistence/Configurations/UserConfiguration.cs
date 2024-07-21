using CMH.Domain.Entities;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(u=>u.Id);
            modelBuilder.HasMany(u => u.Cars).WithOne(c => c.User).HasForeignKey(c => c.UserId);

            var hasher = new PasswordHasher<User>();
            User admin = new User
            {
                Id= "0b72b30a-6053-42b4-99c4-ceebd0cca368",
                Name= "Admin",
                PasswordHash = hasher.HashPassword(null,"P@ssw0rd@123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                Email= "hhoury@hotmail.com",
                DateCreated = DateTime.Now,
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedEmail = "HHOURY@HOTMAIL.COM",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+96170040294",
            };
            User owner = new User
            {
                Id = "1",
                Name = "Owner",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd@123"),
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = "owner@localhost.com",
                DateCreated = DateTime.Now,
                EmailConfirmed = true,
                UserName = "owner",
                NormalizedEmail = "OWNER@LOCALHOST.COM",
                NormalizedUserName = "OWNER",
                PhoneNumber = "+96170040294",
            };

            modelBuilder.HasData(admin);
            modelBuilder.HasData(owner);
        }
    }
}
