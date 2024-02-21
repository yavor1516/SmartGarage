
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class CustomerDataService :ICustomerDataService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly GarageContext _garageContext;

        public CustomerDataService(ICustomerRepository customerRepository, GarageContext garageContext)
        {
            _customerRepository = customerRepository;
            _garageContext = garageContext;
        }

        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                throw new ArgumentNullException(nameof(customerDTO));
            }

            var customerEntity = MapCustomerDTOToEntity(customerDTO);

            var createdCustomer = _customerRepository.CreateCustomer(customerEntity);

            return MapCustomerEntityToDTO(createdCustomer);
        }

        public ICollection<CustomerDTO> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();

            return customers.Select(MapCustomerEntityToDTO).ToList();
        }

        public CustomerDTO GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }

            var customerEntity = _customerRepository.GetCustomerByEmail(email);

            return MapCustomerEntityToDTO(customerEntity);
        }

        public CustomerDTO GetCustomerByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }

            var customerEntity = _customerRepository.GetCustomerByFirstName(firstName);

            return MapCustomerEntityToDTO(customerEntity);
        }

        public CustomerDTO GetCustomerById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var customerEntity = _customerRepository.GetCustomerById(id);

            return MapCustomerEntityToDTO(customerEntity);
        }

        public CustomerDTO GetCustomerByUsername(string username)
        {
            //if (string.IsNullOrWhiteSpace(username))
            //{
            //    throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            //}

            //var customerEntity = _customerRepository.GetCustomerByUsername(username);

            //return MapCustomerEntityToDTO(customerEntity);
            return null;
        }

        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                throw new ArgumentNullException(nameof(customerDTO));
            }

            var customerEntity = MapCustomerDTOToEntity(customerDTO);

            _customerRepository.UpdateCustomer(customerEntity);
        }

        public Customer MapCustomerDTOToEntity(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return null;
            }

            return new Customer
            {
                CustomerID = customerDTO.CustomerID,
                UserID = customerDTO.UserID,
                LinkedVehicles = (ICollection<LinkedVehicles>)customerDTO.LinkedVehicleIDs
            };
        }

        // Helper method to map Customer entity to CustomerDTO
        public CustomerDTO MapCustomerEntityToDTO(Customer customerEntity)
        {
            if (customerEntity == null)
            {
                return null;
            }

            _garageContext.Entry(customerEntity).Collection(c => c.LinkedVehicles).Load();

            // Filter and extract LinkedVehicleIDs for the customer
            var linkedVehicleIDs = customerEntity.LinkedVehicles
                                                .Where(lv => lv.CustomerID == customerEntity.CustomerID)
                                                .Select(lv => lv.LinkedVehicleID)
                                                .ToList();

            // Map Customer entity to DTO
            var customerDTO = new CustomerDTO
            {
                CustomerID = customerEntity.CustomerID,
                UserID = customerEntity.UserID,
                LinkedVehicleIDs = linkedVehicleIDs,
                email = customerEntity.User.Email,
                firstName = customerEntity.User.FirstName,
                lastName = customerEntity.User.LastName,
                phoneNumber = customerEntity.User.phoneNumber,
                username = customerEntity.User.Username
            };

            return customerDTO;
        }
    }
}
