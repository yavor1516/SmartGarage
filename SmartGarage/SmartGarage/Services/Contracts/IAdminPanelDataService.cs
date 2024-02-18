using SmartGarage.Models;
namespace SmartGarage.Services.Contracts
{
    public interface IAdminPanelDataService
    {
        public User BlockUser(string user);
        public User UnBlockUser(string user);
    }
}
