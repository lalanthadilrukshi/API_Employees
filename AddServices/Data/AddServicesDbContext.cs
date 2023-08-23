using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddServices.Models;


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;




namespace AddServices.Data
{
    //public class WebApp_ServicesAdvertiseContext :  DbContext
    //public class WebApp_ServicesAdvertiseContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    public class AddServicesDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
  //  public class AddServicesDbContext : DbContext


    {

        public AddServicesDbContext(DbContextOptions<AddServicesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Province> Province { get; set; }
        public DbSet<Village> Villages { get; set; }

        public DbSet<MainCategory> MainCategorys { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<District> Districts { get; set; }
        public DbSet<City> City { get; set; }


        public DbSet<Service> Service { get; set; }
        public DbSet<Employee> employees { get; set; } // only for testing React
        public DbSet<Company> Company { get; set; } // only for testing React
       
        public DbSet<Service_Image> Service_Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<ApplicationUser>(e =>
            {
                e.HasMany(p => p.Services)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.FKUserId);
            });


            modelBuilder.Entity<Service_Image>()
        .HasOne<Service>(p => p.service)
        .WithMany(q => q.Service_Images)
        .HasForeignKey(r => r.FKServiceId);




            modelBuilder.Seed();

        }
    }
}
