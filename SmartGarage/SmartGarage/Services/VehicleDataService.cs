using SmartGarage.Exceptions;
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

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            return _vehicleRepository.CreateVehicle(vehicle);
        }

        public ICollection<Vehicle> GetAllVehiclesByEmployeeID(int employeeId)
        {
            return _vehicleRepository.GetAllVehiclesByEmployeeID(employeeId);
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);
            if (vehicle == null)
            {
                throw new EntityNotFoundException("Vehicle not found.");
            }
            return vehicle;
        }

        public ICollection<Vehicle> GetVehiclesByManufacturer(string manufacturer)
        {
            return _vehicleRepository.GetVehiclesByManufacturer(manufacturer);
        }

        public Vehicle GetVehicleByModel(string model)
        {
            var vehicle = _vehicleRepository.GetVehicleByModel(model);
            if (vehicle == null)
            {
                throw new EntityNotFoundException("Vehicle with the specified model not found.");
            }
            return vehicle;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {

            var existingVehicle = _vehicleRepository.GetVehicleById(vehicle.VehicleID);
            if (existingVehicle == null)
            {
                throw new EntityNotFoundException("Vehicle to update was not found.");
            }

            // Update properties of existingVehicle with values from the input 'vehicle' object

            _vehicleRepository.UpdateVehicle(existingVehicle);
        }
    }
}
