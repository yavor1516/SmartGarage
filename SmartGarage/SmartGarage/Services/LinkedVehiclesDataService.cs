﻿using SmartGarage.Models;
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
        private readonly IServiceDataService _serviceDataService;
        private readonly GarageContext _dbContext;

        public LinkedVehiclesDataService(ILinkedVehiclesRepository linkedVehiclesRepository, IEmployeeDataService employeeDataService, IVehicleDataService vehicleDataService, ICustomerDataService customerDataService, IServiceDataService serviceDataService, GarageContext dbContext)
        {
            _linkedVehiclesRepository = linkedVehiclesRepository ?? throw new ArgumentNullException(nameof(linkedVehiclesRepository));
            _employeeDataService = employeeDataService;
            _vehicleDataService = vehicleDataService;
            _customerDataService = customerDataService;
            _serviceDataService = serviceDataService;
            _dbContext = dbContext;
        }

        public LinkedVehiclesDTO CreateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO)
        {
            if (linkedVehiclesDTO == null) throw new ArgumentNullException(nameof(linkedVehiclesDTO));

            var linkedVehicleEntity = MapLinkedVehicleDTOToEntity(linkedVehiclesDTO);
            //linkedVehicleEntity. = _dbContext.Services.Where(s => linkedVehiclesDTO.ServiceIDs.Contains(s.ServiceID)).ToList();
            var createdLinkedVehicle = _linkedVehiclesRepository.CreateLinkedVehicle(linkedVehicleEntity);


            return MapLinkedVehicleEntityToDTO(createdLinkedVehicle);
        }

        public ICollection<LinkedVehiclesDTO> GetLinkedVehicleByCustomerId(int customerId)
        {
            if (customerId <= 0) throw new ArgumentException("Customer ID must be greater than zero.", nameof(customerId));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByCustomerId(customerId);

            return linkedVehicleEntity.Select(MapLinkedVehicleEntityToDTO).ToList();
        }

        public ICollection<LinkedVehiclesDTO> GetLinkedVehicleByEmployeeId(int employeeId)
        {
            if (employeeId <= 0) throw new ArgumentException("Employee ID must be greater than zero.", nameof(employeeId));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByEmployeeId(employeeId);

            return linkedVehicleEntity.Select(MapLinkedVehicleEntityToDTO).ToList();
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
        public LinkedVehiclesDTO GetLinkedVehicleByIdWithServices(int id)
        {
            if (id <= 0) throw new ArgumentException("ID must be greater than zero.", nameof(id));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehicleByIdWithServices(id);

            return MapLinkedVehicleEntityToDTO(linkedVehicleEntity);
        }

        public ICollection<LinkedVehiclesDTO> GetLinkedVehicleByModelID(int model)
        {
            if (model<0)
                throw new ArgumentException("Model name cannot be null or whitespace.", nameof(model));

            var linkedVehicleEntity = _linkedVehiclesRepository.GetLinkedVehiclesByModelID(model);

            return linkedVehicleEntity.Select(MapLinkedVehicleEntityToDTO).ToList();
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
                LinkedVehicleID = linkedVehiclesDTO.LinkedVehicleID,
                ModelID = linkedVehiclesDTO.ModelID,
                ManufacturerID = linkedVehiclesDTO.ManufacturerID,
                EmployeeID = linkedVehiclesDTO.EmployeeID,
                CustomerID = linkedVehiclesDTO.CustomerID,
                LicensePlate = linkedVehiclesDTO.LicensePlate,
                VIN = linkedVehiclesDTO.VIN,
                YearOfCreation = linkedVehiclesDTO.YearOfCreation,
                InvoiceID = linkedVehiclesDTO.InvoiceID,
                LinkedVehicleServices = linkedVehiclesDTO.LinkedVehicleServices
                    ?.Select(s => new LinkedVehicleService
                    {
                        LinkedVehicleID = s.LinkedVehicleID,
                        ServiceID = s.ServiceID,
                        Status = false
                    })
                    .ToList(),
                // ServiceID = linkedVehiclesDTO.ServiceID
            };
        }

        private LinkedVehiclesDTO MapLinkedVehicleEntityToDTO(LinkedVehicles linkedVehicleEntity)
        {
            if (linkedVehicleEntity == null)
            {
                return null;
            }

           // var serviceIDs = linkedVehicleEntity.Services?.Select(s => s.ServiceID).ToList();
            //var serviceNames = linkedVehicleEntity.Services?.Select(s => s.Name).ToList();

            return new LinkedVehiclesDTO
            {
                LinkedVehicleID = linkedVehicleEntity.LinkedVehicleID,
                ModelID = linkedVehicleEntity.ModelID,
                ManufacturerID = (int)linkedVehicleEntity.ManufacturerID,
                EmployeeID = (int)linkedVehicleEntity.EmployeeID,
                CustomerID = (int)linkedVehicleEntity.CustomerID,
                LicensePlate = linkedVehicleEntity.LicensePlate,
                VIN = linkedVehicleEntity.VIN,
                YearOfCreation = linkedVehicleEntity.YearOfCreation,
                InvoiceID = linkedVehicleEntity.InvoiceID,
                LinkedVehicleServices = linkedVehicleEntity.LinkedVehicleServices
                        ?.Select(s => new LinkedVehicleServiceDTO
                        {
                            LinkedVehicleID = (int)s.LinkedVehicleID,
                            ServiceID = (int)s.ServiceID,
                            ServiceName = _serviceDataService.GetServiceByID((int)s.ServiceID)?.Name,
                            Status = s.Status == null ? "Not Started" : (s.Status == false ? "In Progress" : "Finished")
                        })
                        .ToList(),

            };
        }
        public void DeleteLinkedVehicle(int linkedVehicleId)
        {
            var linkedVehicle = _linkedVehiclesRepository.GetLinkedVehiclesById(linkedVehicleId);
            if (linkedVehicle == null)
            {
                throw new ArgumentException("Linked vehicle not found.", nameof(linkedVehicleId));
            }

            _linkedVehiclesRepository.DeleteLinkedVehicle(linkedVehicle);
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
