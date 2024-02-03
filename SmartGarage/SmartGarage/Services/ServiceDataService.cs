using SmartGarage.Repositories;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class ServiceDataService : IServiceDataService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceDataService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Service GetServiceById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            return _serviceRepository.GetServiceById(id);
        }

        public Service GetServiceByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            }
            return _serviceRepository.GetServiceByName(name);
        }

        public Service GetServiceByPrice(decimal price)
        {
            return _serviceRepository.GetServiceByPrice(price);
        }

        public ICollection<Service> GetAllServicesById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            return _serviceRepository.GetAllServicesById(id);
        }
        public ICollection<Service> GetAllServices()
        {
            return _serviceRepository.GetAllServices();
        }

        public Service CreateService(Service service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

             var existingService = _serviceRepository.GetServiceByName(service.Name);
             if (existingService != null)
             {
                 throw new InvalidOperationException("Service with the same name already exists.");
             }

            return _serviceRepository.CreateService(service);
        }

        public void UpdateService(Service service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

             var existingService = _serviceRepository.GetServiceById(service.ServiceId);
             if (existingService == null)
             {
                 throw new InvalidOperationException("Service does not exist.");
             }

            _serviceRepository.UpdateService(service);
        }
    }
}
