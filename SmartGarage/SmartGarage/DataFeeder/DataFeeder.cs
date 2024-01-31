using System;
using System.Linq;

namespace SmartGarage.DataFeeder
{
    public class DataFeeder
    {
        public static void Initialize(GarageContext context)
        {
             context.Database.EnsureCreated(); // Ensure the database is created

            if (context.Users.Any() || context.Vehicles.Any() || context.CarModels.Any() || context.Manufacturers.Any() || context.Employees.Any())
            {
                return; // Database has been seeded
            }

            // Create Manufacturers
            var manufacturers = new[]
            {
                new Manufacturer { BrandName = "Toyota" },
                new Manufacturer { BrandName = "Honda" },
                // Add more manufacturers as needed
            };
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            // Create Car Models
            var carModels = new[]
            {
                new CarModel { Model = "Camry", ManufacturerID = manufacturers[0].ManufacturerID },
                new CarModel { Model = "Civic", ManufacturerID = manufacturers[1].ManufacturerID },
                // Add more car models as needed
            };
            context.CarModels.AddRange(carModels);
            context.SaveChanges();

            // Create Users
            var users = new[]
            {
                new User { Username = "admin", Email = "admin@example.com", FirstName = "Admin", LastName = "User", isOnline = true, phoneNumber = "1234567890", RegistrationDate = DateTime.Now, PasswordHash = new byte[32] },
                new User { Username = "employee1", Email = "employee1@example.com", FirstName = "John", LastName = "Doe", isOnline = true, phoneNumber = "9876543210", RegistrationDate = DateTime.Now, PasswordHash = new byte[32] },
                new User { Username = "employee2", Email = "employee2@example.com", FirstName = "Jane", LastName = "Smith", isOnline = false, phoneNumber = "5555555555", RegistrationDate = DateTime.Now, PasswordHash = new byte[32] },
                // Add more users as needed
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            // Create Employees
            var employees = new[]
            {
                new Employee { UserID = users[1].UserID, IsAdmin = true }, // Make employee1 an admin
                new Employee { UserID = users[2].UserID, IsAdmin = false },
                // Add more employees as needed
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            // Create Vehicles
            var vehicles = new[]
            {
                new Vehicle { ManufacturerId = manufacturers[0].ManufacturerID, CarModelID = carModels[0].CarModelID },
                new Vehicle { ManufacturerId = manufacturers[1].ManufacturerID, CarModelID = carModels[1].CarModelID },
                // Add more vehicles as needed
            };
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
        }
    }
}
