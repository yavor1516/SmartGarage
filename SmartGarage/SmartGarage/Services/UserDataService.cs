using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;
        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
        public User GetUserById(int id)
        {

            return _userRepository.GetUserById(id);
        }
        public User CreateUser(User user , bool isCustomer)
        {
           
            return _userRepository.CreateUser(user , isCustomer);
        }
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}
