namespace SmartGarage.Services.Contracts
{
    public interface ICustomerDataService
    {
        Customer CreateCustomer(Customer customer);
        ICollection<Customer> GetAllCustomers();
        Customer GetCustomerByEmail(string email);
        Customer GetCustomerByFirstName(string firstName);
        Customer GetCustomerById(int id);
        Customer GetCustomerByUsername(string username);
        void UpdateCustomer(Customer customer);
    }
}
