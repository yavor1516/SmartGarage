using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
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
           return _dbcontext.Vehicles.Where(x=>x.EmployeeId == id)
                .Include(m => m.Manufacturer).Include(n => n.CarModel).ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            var db = _dbcontext.Vehicles.Include(m=>m.Manufacturer).Include(n=>n.CarModel).ToList();
            var vehicle = db.FirstOrDefault(x => x.VehicleID == id);
            return vehicle;    
        }

        public ICollection<Vehicle> GetVehiclesByManufacturerName(string Manufacturer)
        {
            return _dbcontext.Vehicles.Where(x => x.Manufacturer.BrandName == Manufacturer)
                .Include(m => m.Manufacturer).Include(n => n.CarModel).ToList();
         }

        public ICollection<Vehicle> GetVehicleByModel(string Model)
        {
            var vehicles = _dbcontext.Vehicles.Include(m => m.Manufacturer).Include(m => m.CarModel)
                .Where(x => x.CarModel.Model == Model).ToList();

            return vehicles;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _dbcontext.SaveChanges();
        }

        public ICollection<Vehicle> GetAllVehicles()
        {
            return _dbcontext.Vehicles.Include(m => m.Manufacturer).Include(n => n.CarModel).ToList();
        }
    }

    

}