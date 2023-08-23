using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AddServices.Models;

namespace AddServices.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "masteradmin",
                NormalizedUserName = "MASTERADMIN",
                FirstName = "Master",
                LastName = "Admin",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1980, 1, 1),
                SecurityStamp = new Guid().ToString("D"),
               // UserType = UserType.Administrator
            };

            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }

        public string PassGenerate(ApplicationUser user)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, "password");
        }
    }
}
