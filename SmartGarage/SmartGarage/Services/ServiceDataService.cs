using SmartGarage.Models.DTO;
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

        public ServiceDTO GetServiceByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var service = _serviceRepository.GetServiceByID(id);

            // Manually map Service to ServiceDTO
            return MapServiceToDTO(service);
        }

        public ServiceDTO GetServiceByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            }

            var service = _serviceRepository.GetServiceByName(name);

            // Manually map Service to ServiceDTO
            return MapServiceToDTO(service);
        }

        public ServiceDTO GetServiceByPrice(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price must be greater than zero.", nameof(price));
            }

            var service = _serviceRepository.GetServiceByPrice(price);

            // Manually map Service to ServiceDTO
            return MapServiceToDTO(service);
        }

        public ICollection<ServiceDTO> GetAllServicesByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var services = _serviceRepository.GetAllServicesById(id);

            // Manually map list of Service to list of ServiceDTO
            return services.Select(MapServiceToDTO).ToList();
        }

        public ICollection<ServiceDTO> GetAllServices()
        {
            var services = _serviceRepository.GetAllServices();

            // Manually map list of Service to list of ServiceDTO
            return services.Select(MapServiceToDTO).ToList();
        }

        public Service CreateService(ServiceDTO serviceDTO)
        {
            if (serviceDTO == null)
            {
                throw new ArgumentNullException(nameof(serviceDTO));
            }

            var service = new Service
            {
                // Map properties from serviceDTO to service
                EmployeeID = serviceDTO.EmployeeID,
                Name = serviceDTO.Name,
                Price = serviceDTO.Price
                // Add any other properties that need to be mapped
            };

            var existingService = _serviceRepository.GetServiceByName(serviceDTO.Name);
            if (existingService != null)
            {
                throw new InvalidOperationException("Service with the same name already exists.");
            }

            return _serviceRepository.CreateService(service);
        }

        public void UpdateService(ServiceDTO serviceDTO)
        {
            if (serviceDTO == null)
            {
                throw new ArgumentNullException(nameof(serviceDTO));
            }

            // Manually map properties from ServiceDTO to Service
            var service = new Service
            {
                ServiceID = serviceDTO.ServiceID,
                EmployeeID = serviceDTO.EmployeeID,
                Name = serviceDTO.Name,
                Price = serviceDTO.Price
                
            };

            var existingService = _serviceRepository.GetServiceByID(service.ServiceID);
            if (existingService == null)
            {
                throw new InvalidOperationException("Service does not exist.");
            }

            _serviceRepository.UpdateService(service);
        }

        //Manual Mapper
        public ServiceDTO MapServiceToDTO(Service service)
        {
            return new ServiceDTO
            {
                ServiceID = service.ServiceID,
                EmployeeID = service.EmployeeID,
                Name = service.Name,
                Price = service.Price
            };
        }
    }
}
