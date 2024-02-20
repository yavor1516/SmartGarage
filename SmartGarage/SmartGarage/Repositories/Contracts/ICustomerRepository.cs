using SmartGarage.Models.DTO;

namespace SmartGarage.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByFirstName(string firstName);
        public CustomerProfileDTO GetCustomerByUsername(string username);
        public Customer GetCustomerByEmail(string email);
        public ICollection<Customer> GetAllCustomers();
        public Customer CreateCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
    }
}
