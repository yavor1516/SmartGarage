using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
        public DbSet<Manufacturer>? Manufacturers { get; set; }
        public DbSet<Service>? Services{ get; set; }
        public DbSet<User>? Users{ get; set; }
        public DbSet<Vehicle>? Vehicles{ get; set; }
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }
    }
}
