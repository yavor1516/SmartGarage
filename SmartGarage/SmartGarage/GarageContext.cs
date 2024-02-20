using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SmartGarage.Models;

namespace SmartGarage
{
    public class GarageContext : DbContext
    {
        public GarageContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CarModel>? CarModels { get; set; }
        public DbSet<Customer>? Customers{ get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<LinkedVehicles>? LinkedVehicles{ get; set; }
        public DbSet<LinkedVehicleService>? LinkedVehicleService { get; set; }
        public DbSet<Manufacturer>? Manufacturers { get; set; }
        public DbSet<Service>? Services{ get; set; }
        public virtual DbSet<User>? Users{ get; set; }
        public DbSet<Vehicle>? Vehicles{ get; set; }
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call base method
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();

            modelBuilder.Entity<LinkedVehicleService>()
            .HasOne(lvs => lvs.LinkedVehicle)
            .WithMany(lv => lv.LinkedVehicleServices)
            .HasForeignKey(lvs => lvs.LinkedVehicleID)
            .OnDelete(DeleteBehavior.Restrict); // Set the delete behavior to Restrict

            modelBuilder.Entity<LinkedVehicleService>()
                .HasOne(lvs => lvs.Service)
                .WithMany(s => s.LinkedVehicleServices)
                .HasForeignKey(lvs => lvs.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
