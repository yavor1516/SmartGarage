using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class LinkedVehiclesDataService : ILinkedVehiclesDataService
    {
        private readonly ILinkedVehiclesRepository _linkedVehiclesRepository;
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IVehicleDataService _vehicleDataService;
        private readonly ICustomerDataService _customerDataService;
        private readonly GarageContext _dbContext;

        public LinkedVehiclesDataService(ILinkedVehiclesRepository linkedVehiclesRepository, IEmployeeDataService employeeDataService, IVehicleDataService vehicleDataService, ICustomerDataService customerDataService, GarageContext dbContext)
        {
            _linkedVehiclesRepository = linkedVehiclesRepository ?? throw new ArgumentNullException(nameof(linkedVehiclesRepository));
            _employeeDataService = employeeDataService;
            _vehicleDataService = vehicleDataService;
            _customerDataService = customerDataService;
            _dbContext = dbContext;
        }

        public LinkedVehiclesDTO CreateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO)
        {
            if (linkedVehiclesDTO == null) throw new ArgumentNullException(nameof(linkedVehiclesDTO));

            var linkedVehicleEntity = MapLinkedVehicleDTOToEntity(linkedVehiclesDTO);
            var createdLinkedVehicle = _linkedVehiclesRepository.CreateLinkedVehicle(linkedVehicleEntity);

            _dbContext.Entry(createdLinkedVehicle).Collection(lv => lv.Services).Load();

            return MapLinkedVehicleEntityToDTO(createdLinkedVehicle);
        }

        public LinkedVehiclesDTO GetLinkedVehicleByCustomerId(int customerId)
        {
            if (customerId <= 0) throw new ArgumentException("Customer ID must be greater than zero.", nameof(customerId));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByCustomerId(customerId);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public LinkedVehiclesDTO GetLinkedVehicleByCustomerName(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or whitespace.", nameof(customerName));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByCustomerName(customerName);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public LinkedVehiclesDTO GetLinkedVehicleByEmployeeId(int employeeId)
        {
            if (employeeId <= 0) throw new ArgumentException("Employee ID must be greater than zero.", nameof(employeeId));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByEmployeeId(employeeId);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public LinkedVehiclesDTO GetLinkedVehicleByEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                throw new ArgumentException("Employee name cannot be null or whitespace.", nameof(employeeName));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByEmployeeName(employeeName);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public LinkedVehiclesDTO GetLinkedVehicleById(int id)
        {
            if (id <= 0) throw new ArgumentException("ID must be greater than zero.", nameof(id));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesById(id);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public LinkedVehiclesDTO GetLinkedVehicleByLicensePlate(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("License plate cannot be null or whitespace.", nameof(licensePlate));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByLicensePlate(licensePlate);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public LinkedVehiclesDTO GetLinkedVehicleByModelName(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model name cannot be null or whitespace.", nameof(model));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByModelName(model);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public ICollection<LinkedVehiclesDTO> GetAllLinkedVehiclesById(int id)
        {
           // if (id <= 0) throw new ArgumentException("ID must be greater than zero.", nameof(id));

            var linkedVehiclesEntities = _linkedVehiclesRepository.GetAllLinkedVehiclesById(id);

            return linkedVehiclesEntities.Select(MapLinkedVehicleEntityToDTO).ToList();
        }

        public void UpdateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO)
        {
            if (linkedVehiclesDTO == null) throw new ArgumentNullException(nameof(linkedVehiclesDTO));

            var linkedVehicleEntity = MapLinkedVehicleDTOToEntity(linkedVehiclesDTO);

            _linkedVehiclesRepository.UpdateLinkedVehicles(linkedVehicleEntity);
        }


        private LinkedVehicles MapLinkedVehicleDTOToEntity(LinkedVehiclesDTO linkedVehiclesDTO)
        {
            if (linkedVehiclesDTO == null)
            {
                return null;
            }


            return new LinkedVehicles
            {
                LinkedVehiclelID = linkedVehiclesDTO.LinkedVehiclelID,
                Model = linkedVehiclesDTO.Model,
                VehicleID = linkedVehiclesDTO.VehicleID,
                EmployeeID = linkedVehiclesDTO.EmployeeID,
                CustomerID = linkedVehiclesDTO.CustomerID,
                LicensePlate = linkedVehiclesDTO.LicensePlate,
                VIN = linkedVehiclesDTO.VIN,
                YearOfCreation = linkedVehiclesDTO.YearOfCreation,
                ServiceID = linkedVehiclesDTO.ServiceID
            };
        }

        private LinkedVehiclesDTO MapLinkedVehicleEntityToDTO(LinkedVehicles linkedVehicleEntity)
        {
            if (linkedVehicleEntity == null)
            {
                return null;
            }

            var serviceName = _dbContext.Services.FirstOrDefault(s => s.ServiceID == linkedVehicleEntity.ServiceID)?.Name;

            return new LinkedVehiclesDTO
            {
                LinkedVehiclelID = linkedVehicleEntity.LinkedVehiclelID,
                Model = linkedVehicleEntity.Model,
                VehicleID = (int)linkedVehicleEntity.VehicleID,
                EmployeeID = (int)linkedVehicleEntity.EmployeeID,
                CustomerID = (int)linkedVehicleEntity.CustomerID,
                LicensePlate = linkedVehicleEntity.LicensePlate,
                VIN = linkedVehicleEntity.VIN,
                YearOfCreation = linkedVehicleEntity.YearOfCreation,
                ServiceID=linkedVehicleEntity.ServiceID,
                ServiceName = serviceName
            };
        }

        private Service MapServiceDTOToEntity(ServiceDTO serviceDTO)
        {
            return new Service
            {
                ServiceID = serviceDTO.ServiceID,
                Name = serviceDTO.Name,
                Price = serviceDTO.Price
            };
        }
        private ServiceDTO MapServiceEntityToDTO(Service serviceEntity)
        {
            return new ServiceDTO
            {
                ServiceID = serviceEntity.ServiceID,
                Name = serviceEntity.Name,
                Price = serviceEntity.Price
            };
        }
        private VehicleDTO MapVehicleEntityToDTO(Vehicle vehicleEntity)
        {
            return _vehicleDataService.MapVehicleEntityToDTO(vehicleEntity);
        }
        private Vehicle MapVehicleDTOToEntity(VehicleDTO vehicleDTO)
        {
            return _vehicleDataService.MapVehicleDTOToEntity(vehicleDTO);
        }
        private EmployeeDTO MapEmployeeEntityToDTO(Employee employeeEntity)
        {
            return _employeeDataService.MapEmployeeEntityToDTO(employeeEntity);
        }
        private Employee MapEmployeeDTOToEntity(EmployeeDTO employeeDTO)
        {
            return _employeeDataService.MapEmployeeDTOToEntity(employeeDTO);
        }
        private CustomerDTO MapCustomerEntityToDTO(Customer customerEntity)
        {
            return _customerDataService.MapCustomerEntityToDTO(customerEntity);
        }
        private Customer MapCustomerDTOToEntity(CustomerDTO customerDTO)
        {
            return _customerDataService.MapCustomerDTOToEntity(customerDTO);
        }
    }
}
