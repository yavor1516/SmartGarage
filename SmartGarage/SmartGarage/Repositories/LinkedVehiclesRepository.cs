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
        public LinkedVehicles GetLinkedVehiclesByCustomerId(int customerId)
        {
            return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.CustomerID ==customerId);
        }

        public LinkedVehicles GetLinkedVehiclesByCustomerName(string customerName)
        {
            return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.Customer.User.Username == customerName);
        }

        public LinkedVehicles GetLinkedVehiclesByEmployeeId(int employeeId)
        {
            return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.EmployeeID == employeeId);
        }

        public LinkedVehicles GetLinkedVehiclesByEmployeeName(string employeeName)
        {
           return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.Employee.User.Username == employeeName);
        }

        public LinkedVehicles GetLinkedVehiclesById(int id)
        {
           return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.LinkedVehiclelID == id);
        }

        public LinkedVehicles GetLinkedVehiclesByLicensePlate(string licensePlate)
        {
            return _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.LicensePlate == licensePlate);
        }

        public LinkedVehicles GetLinkedVehiclesByModelName(string model)
        {
           return  _dbcontext.LinkedVehicles.FirstOrDefault(x=>x.Model == model);
        }

        public ICollection<LinkedVehicles> GetAllLinkedVehiclesById(int id)
        {
            return _dbcontext.LinkedVehicles.Where(x=>x.LinkedVehiclelID==id).ToList();
        }

        public void UpdateLinkedVehicle(LinkedVehicles linkedVehicle)
        {
            _dbcontext.SaveChanges();
        }
       
    }
}
