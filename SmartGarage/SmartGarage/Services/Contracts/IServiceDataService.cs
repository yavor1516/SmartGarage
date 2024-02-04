using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IServiceDataService
    {
        ServiceDTO GetServiceByID(int id);
        ServiceDTO GetServiceByName(string name);
        ServiceDTO GetServiceByPrice(decimal price);
        ICollection<ServiceDTO> GetAllServicesByID(int id);
        ICollection<ServiceDTO> GetAllServices();
        Service CreateService(ServiceDTO serviceDTO);
        void UpdateService(ServiceDTO serviceDTO);
    }
}
