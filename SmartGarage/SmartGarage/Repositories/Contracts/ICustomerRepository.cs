namespace SmartGarage.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByFirstName(string firstName);
        public Customer GetCustomerByUsername(string username);
        public Customer GetCustomerByEmail(string email);
        public ICollection<Customer> GetAllCustomers();
        public Customer CreateCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
    }
}
