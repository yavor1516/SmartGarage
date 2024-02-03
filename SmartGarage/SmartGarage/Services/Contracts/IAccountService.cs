using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IAccountService
    {
        public string GenerateToken(User user);
      
        public User RegisterUser(RegisterUserDTO registerUserDTO);

        public User LoginUser(LoginUserDTO loginUserDTO);

    }
}
