using Microsoft.EntityFrameworkCore;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class VehicleDataService : IVehicleDataService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly GarageContext _garageContext;

        public VehicleDataService(IVehicleRepository vehicleRepository , GarageContext garageContext)
        {
            _vehicleRepository = vehicleRepository;
            _garageContext = garageContext;
        }

        public VehicleDTO CreateVehicle(VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null)
            {
                throw new ArgumentNullException(nameof(vehicleDTO));
            }

            var vehicleEntity = MapVehicleDTOToEntity(vehicleDTO);

            //if (string.IsNullOrWhiteSpace(vehicleEntity.Manufacturer?.BrandName))
            //{
            //    throw new ArgumentException("Manufacturer is required.");
            //}

            var createdVehicle = _vehicleRepository.CreateVehicle(vehicleEntity);

            return MapVehicleEntityToDTO(createdVehicle);
        }

        public ICollection<VehicleDTO> GetAllVehiclesByEmployeeID(int employeeId)
        {
            var vehicles = _vehicleRepository.GetAllVehiclesByEmployeeID(employeeId);

            return vehicles.Select(MapVehicleEntityToDTO).ToList();
        }

        public VehicleDTO GetVehicleByID(int vehicleId)
        {
            var vehicleEntity = _vehicleRepository.GetVehicleById(vehicleId);
            if (vehicleEntity == null)
            {
                throw new EntityNotFoundException("Vehicle not found.");
            }

            return MapVehicleEntityToDTO(vehicleEntity);
        }

        public ICollection<VehicleDTO> GetVehiclesByManufacturer(string manufacturer)
        {
            var vehicles = _vehicleRepository.GetVehiclesByManufacturer(manufacturer);

            return vehicles.Select(MapVehicleEntityToDTO).ToList();
        }

        public VehicleDTO GetVehicleByModel(string model)
        {
            var vehicleEntity = _vehicleRepository.GetVehicleByModel(model);
            if (vehicleEntity == null)
            {
                throw new EntityNotFoundException("Vehicle with the specified model not found.");
            }

            return MapVehicleEntityToDTO(vehicleEntity);
        }

        public void UpdateVehicle(VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null)
            {
                throw new ArgumentNullException(nameof(vehicleDTO));
            }

            var vehicleEntity = MapVehicleDTOToEntity(vehicleDTO);

            var existingVehicle = _vehicleRepository.GetVehicleById(vehicleEntity.VehicleID);
            if (existingVehicle == null)
            {
                throw new EntityNotFoundException("Vehicle to update was not found.");
            }

            
            
            existingVehicle.ManufacturerId = vehicleEntity.ManufacturerId;
            existingVehicle.CarModelID = vehicleEntity.CarModelID;
            existingVehicle.EmployeeId = vehicleEntity.EmployeeId;

            _vehicleRepository.UpdateVehicle(existingVehicle);
        }

        public ICollection<VehicleDTO> GetAllVehicles()
        {
            var vehicles = _vehicleRepository.GetAllVehicles();

            return vehicles.Select(MapVehicleEntityToDTO).ToList();
        }

        public Vehicle MapVehicleDTOToEntity(VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null)
            {
                return null;
            }

            int? manufacturerId = GetManufacturerIdByName(vehicleDTO.Manufacturer);
            int? carModelId = GetCarModelIdByName(vehicleDTO.CarModel);

            return new Vehicle
            {
                VehicleID = vehicleDTO.VehicleID,
                ManufacturerId = manufacturerId,
                CarModelID = carModelId,
                EmployeeId = vehicleDTO.EmployeeID
            };
        }

        public VehicleDTO MapVehicleEntityToDTO(Vehicle vehicleEntity)
        {
            if (vehicleEntity == null)
            {
                return null;
            }

            return new VehicleDTO
            {
                VehicleID = vehicleEntity.VehicleID,
                Manufacturer = vehicleEntity.Manufacturer?.BrandName, 
                CarModel = vehicleEntity.CarModel?.Model, 
                EmployeeID = vehicleEntity.EmployeeId ?? 0
            };
        }
        public int? GetManufacturerIdByName(string name)
        {
            var manufacturer = _garageContext.Manufacturers
                                       .FirstOrDefault(m => m.BrandName == name);

            return manufacturer?.ManufacturerID;
        }
        public int? GetCarModelIdByName(string name)
        {
            var carModel = _garageContext.CarModels
                                   .FirstOrDefault(cm => cm.Model == name);

            return carModel?.CarModelID;
        }
    }
}
