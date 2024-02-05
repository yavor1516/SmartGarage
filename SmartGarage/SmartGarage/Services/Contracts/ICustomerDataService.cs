using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface ICustomerDataService
    {
        CustomerDTO CreateCustomer(CustomerDTO customerDTO);
        ICollection<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerByEmail(string email);
        CustomerDTO GetCustomerByFirstName(string firstName);
        CustomerDTO GetCustomerById(int id);
        CustomerDTO GetCustomerByUsername(string username);
        void UpdateCustomer(CustomerDTO customerDTO);
        CustomerDTO MapCustomerEntityToDTO(Customer customer);
        Customer MapCustomerDTOToEntity(CustomerDTO customerDTO);
    }
}
