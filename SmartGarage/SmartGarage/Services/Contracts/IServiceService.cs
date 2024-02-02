namespace SmartGarage.Services.Contracts
{
    public interface IServiceService
    {
        Service GetServiceById(int id);
        Service GetServiceByName(string name);
        Service GetServiceByPrice(decimal price);
        ICollection<Service> GetAllServicesById(int id);
        Service CreateService(Service service);
        void UpdateService(Service service);
    }
}
