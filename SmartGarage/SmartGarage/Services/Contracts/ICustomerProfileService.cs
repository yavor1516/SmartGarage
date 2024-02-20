using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface ICustomerProfileService
    {
        public CustomerProfileDTO GetUserByUsername(string username);
    }
}
