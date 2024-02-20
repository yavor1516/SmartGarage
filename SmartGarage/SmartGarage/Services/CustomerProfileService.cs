using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class CustomerProfileService : ICustomerProfileService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerProfileService(ICustomerRepository customerRepository)
        {
         
            _customerRepository = customerRepository;
        }


        public CustomerProfileDTO GetUserByUsername(string username)
        {
          return _customerRepository.GetCustomerByUsername(username);

        }
    }
}
