using Microsoft.EntityFrameworkCore;
using SmartGarage.Repositories.Contracts;
using System.Collections.Specialized;

namespace SmartGarage.Repositories
{
    public class LinkedVehiclesRepository : ILinkedVehiclesRepository
    {
        private readonly GarageContext _dbcontext;
        public LinkedVehiclesRepository(GarageContext dbcontext) 
        {
            _dbcontext=dbcontext;
        }
        public LinkedVehicles CreateLinkedVehicle(LinkedVehicles linkedVehicles)
        {
            _dbcontext.LinkedVehicles.Add(linkedVehicles);
            _dbcontext.SaveChanges();
            return linkedVehicles;
        }
        public ICollection<LinkedVehicles> GetLinkedVehiclesByCustomerId(int customerId)
        {
            return _dbcontext.LinkedVehicles.Where(x => x.CustomerID == customerId).ToList();
        }

        public LinkedVehicles GetLinkedVehiclesByCustomerName(string customerName)
        {
            return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.Customer.User.Username == customerName);
        }
        public LinkedVehicles GetLinkedVehicleByIdWithServices(int id)
        {
            return _dbcontext.LinkedVehicles
                .Include(lv => lv.LinkedVehicleServices)
                .ThenInclude(lvs => lvs.Service)
                .Include(man=>man.Manufacturer)
                .ThenInclude(x=>x.CarModels)
                   
                .FirstOrDefault(lv => lv.LinkedVehicleID == id);
        }
        public ICollection<LinkedVehicles> GetLinkedVehiclesByEmployeeId(int employeeId)
        {
            return _dbcontext.LinkedVehicles.Where(x => x.EmployeeID == employeeId).ToList();
        }

        public LinkedVehicles GetLinkedVehiclesByEmployeeName(string employeeName)
        {
           return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.Employee.User.Username == employeeName);
        }

        public LinkedVehicles GetLinkedVehiclesById(int id)
        {
           return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.LinkedVehicleID == id);
        }

        public LinkedVehicles GetLinkedVehiclesByLicensePlate(string licensePlate)
        {
            return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.LicensePlate == licensePlate);
        }

        public ICollection<LinkedVehicles> GetLinkedVehiclesByModelID(int model)
        {
           return  _dbcontext.LinkedVehicles.Where(x => x.ModelID == model).ToList();
        }

        public ICollection<LinkedVehicles> GetAllLinkedVehiclesById(int id)
        {
            return _dbcontext.LinkedVehicles.Where(x=>x.LinkedVehicleID==id).ToList();
        }

        public void UpdateLinkedVehicles(LinkedVehicles linkedVehicles)
        {
            _dbcontext.SaveChanges();
        }
        public void DeleteLinkedVehicle(LinkedVehicles linkedVehicle)
        {
            _dbcontext.LinkedVehicles.Remove(linkedVehicle);
            _dbcontext.SaveChanges();
        }
    }
}
