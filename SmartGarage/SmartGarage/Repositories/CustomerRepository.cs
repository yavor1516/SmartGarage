using Microsoft.EntityFrameworkCore;
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

        public Customer GetCustomerByUsername(string username)
        {
            Customer customer = _dbcontext.Customers.FirstOrDefault(x => x.User.Username == username);
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbcontext.SaveChanges();
        }
    }
}
