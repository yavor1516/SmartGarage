using Microsoft.EntityFrameworkCore;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly GarageContext _dbcontext;

        public CustomerRepository(GarageContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Customer CreateCustomer(Customer customer)
        {
            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            return customer;
        }

        public ICollection<Customer> GetAllCustomers()
        {
            return _dbcontext.Customers.Include(x => x.LinkedVehicles).Include(c=>c.User).ToList(); ;
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = _dbcontext.Customers.FirstOrDefault(x => x.User.Email == email);
            return customer;
        }

        public Customer GetCustomerByFirstName(string firstName)
        {
            Customer customer = _dbcontext.Customers.FirstOrDefault(x => x.User.FirstName == firstName);
            return customer;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _dbcontext.Customers.FirstOrDefault(x => x.CustomerID == id);
            return customer;
        }

        public CustomerProfileDTO GetCustomerByUsername(string username)
        {
            Customer customer = _dbcontext.Customers
                               .Include(c => c.LinkedVehicles)
                               .ThenInclude(m=>m.Manufacturer)
                               .ThenInclude(mod=>mod.CarModels)
                               .Include(c => c.LinkedVehicles)
                               .ThenInclude(e=>e.Employee)
                               .ThenInclude(u=>u.User)
                                .Include(c => c.LinkedVehicles)
                               .ThenInclude(i=>i.Invoice)
                                .Include(c => c.LinkedVehicles)
                                    .ThenInclude(s => s.LinkedVehicleServices)
                                    .ThenInclude(c=>c.Service)
                               .FirstOrDefault(x => x.User.Username == username);

            User user = _dbcontext.Users.FirstOrDefault(x => x.Username == username);
            CustomerProfileDTO Profile = new CustomerProfileDTO()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.phoneNumber,
                Vehicles = customer.LinkedVehicles.Select(v => new AssignedVehiclesDTO
                {
                    Manufacturer = v.Manufacturer.BrandName,
                    Model = v.Model.Model,
                    EmployeeName = v.Employee.User.Username,
                    LicensePlate = v.LicensePlate,
                    WinNumber = v.VIN,
                    yearOfCreation = v.YearOfCreation,
                   services = v.LinkedVehicleServices.Select(s=>new LinkedVehicleServiceDTO
                   {
                        ServiceName = s.Service.Name,

                       Status = s.Status == null ? "Not Started" : (s.Status == false ? "In Progress" : "Finished")
                   }).ToList()
                    }).ToList()
                
            };
            return Profile;
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbcontext.SaveChanges();
        }
    }
}
