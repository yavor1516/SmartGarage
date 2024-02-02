namespace SmartGarage.Services.Contracts
{
    public interface IServiceDataService
    {
        Service GetServiceById(int id);
        Service GetServiceByName(string name);
        Service GetServiceByPrice(decimal price);
        ICollection<Service> GetAllServicesById(int id);
        ICollection<Service> GetAllServices();
        Service CreateService(Service service);
        void UpdateService(Service service);
    }
}
