using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class VehicleDataService : IVehicleDataService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleDataService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public VehicleDTO CreateVehicle(VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null)
            {
                throw new ArgumentNullException(nameof(vehicleDTO));
            }

            var vehicleEntity = MapVehicleDTOToEntity(vehicleDTO);

            if (string.IsNullOrWhiteSpace(vehicleEntity.Manufacturer?.BrandName))
            {
                throw new ArgumentException("Manufacturer is required.");
            }

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

            existingVehicle.Manufacturer = vehicleEntity.Manufacturer;
            existingVehicle.CarModel = vehicleEntity.CarModel;
            existingVehicle.Employee = vehicleEntity.Employee;

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

            return new Vehicle
            {
                //VehicleID = vehicleDTO.VehicleID,
                //Manufacturer = vehicleDTO.Manufacturer.BrandName,
                //CarModel = vehicleDTO.CarModel.Model,
                //Employee = vehicleDTO.Employee.EmployeeID
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
                Manufacturer = vehicleEntity.Manufacturer.BrandName,
                CarModel = vehicleEntity.CarModel.Model,
                EmployeeID = (int)vehicleEntity.EmployeeId
            };
        }
    }
}
