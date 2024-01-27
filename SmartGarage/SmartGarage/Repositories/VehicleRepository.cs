using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly GarageContext _dbcontext;

        public VehicleRepository(GarageContext dbContext)
        { 
            _dbcontext = dbContext;

        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            _dbcontext.Vehicles.Add(vehicle);
            _dbcontext.SaveChanges();
            return vehicle;
        }

        public ICollection<Vehicle> GetAllVehiclesByEmployeeID(int id)
        {
           return _dbcontext.Vehicles.Where(x=>x.EmployeeId == id).ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _dbcontext.Vehicles.FirstOrDefault(x=>x.VehicleID == id);    
        }

        public ICollection<Vehicle> GetVehiclesByManufacturer(string Manufacturer)
        {
            return _dbcontext.Vehicles.Where(x => x.Manufacturer.BrandName == Manufacturer).ToList();
         }

        public Vehicle GetVehicleByModel(string Model)
        {
            return _dbcontext.Vehicles.FirstOrDefault(x=>x.CarModel.Model == Model);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _dbcontext.SaveChanges();
        }
    }

    

}