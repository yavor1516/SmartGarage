using SmartGarage.Exceptions;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;
using System.Text.RegularExpressions;

namespace SmartGarage.Services
{
    public class CustomerDataService :ICustomerDataService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDataService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

           
            if (string.IsNullOrWhiteSpace(customer.User.Email) || !IsValidEmail(customer.User.Email)) //TODO  Email validation!!!!!!!!!!
            {
                throw new ArgumentException("Invalid email address.");
            }

            var existingCustomer = _customerRepository.GetCustomerByEmail(customer.User.Email);
            if (existingCustomer != null)
            {
                throw new InvalidOperationException("A customer with this email already exists.");
            }

            customer.User.Email = customer.User.Email.Trim().ToLower();
            return _customerRepository.CreateCustomer(customer);
        }
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public ICollection<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerRepository.GetCustomerByEmail(email);
        }

        public Customer GetCustomerByFirstName(string firstName)
        {
            return _customerRepository.GetCustomerByFirstName(firstName);
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new EntityNotFoundException("Customer not found.");
            }
            return customer;
        }

        public Customer GetCustomerByUsername(string username)
        {
            return _customerRepository.GetCustomerByUsername(username);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customerRepository.GetCustomerById(customer.CustomerID);
            if (existingCustomer == null)
            {
                throw new EntityNotFoundException("Customer to update was not found.");
            }
            existingCustomer.LinkedVehicles=customer.LinkedVehicles;
           // existingCustomer.CustomerID=customer.CustomerID;               //TODO-not sure if we need to update this

            _customerRepository.UpdateCustomer(existingCustomer);
        }


    }
}
