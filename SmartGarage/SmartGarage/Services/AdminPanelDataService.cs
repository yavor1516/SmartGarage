using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;
using SmartGarage.Repositories;
using SmartGarage.Models;

namespace SmartGarage.Services
{
    public class AdminPanelDataService : IAdminPanelDataService
    {
        private readonly IUserRepository _userRepository;

        public AdminPanelDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User BlockUser(string user)
        {
            var userToBlock =  _userRepository.GetUserByUsername(user);
            userToBlock.isBlocked = true;
            _userRepository.UpdateUser(userToBlock);
            return userToBlock;
        }

        public User UnBlockUser(string user)
        {
            var userToBlock = _userRepository.GetUserByUsername(user);
            userToBlock.isBlocked = false;
            _userRepository.UpdateUser(userToBlock);
            return userToBlock;
        }
    }

}
