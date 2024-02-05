using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IVehicleDataService
    {
        VehicleDTO CreateVehicle(VehicleDTO vehicleDTO);
        ICollection<VehicleDTO> GetAllVehicles();
        ICollection<VehicleDTO> GetAllVehiclesByEmployeeID(int employeeId);
        VehicleDTO GetVehicleByID(int vehicleId);
        ICollection<VehicleDTO> GetVehiclesByManufacturer(string manufacturer);
        VehicleDTO GetVehicleByModel(string model);
        void UpdateVehicle(VehicleDTO vehicleDTO);
        Vehicle MapVehicleDTOToEntity(VehicleDTO vehicleDTO);
        VehicleDTO MapVehicleEntityToDTO(Vehicle vehicle);
    }
}
