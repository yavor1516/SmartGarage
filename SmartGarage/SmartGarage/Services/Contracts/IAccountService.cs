using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IAccountService
    {
        public User RegisterUser(RegisterUserDTO registerUserDTO);
    }
}
