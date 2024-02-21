using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface ILinkedVehiclesDataService
    {
        LinkedVehiclesDTO CreateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO);
        ICollection<LinkedVehiclesDTO> GetLinkedVehicleByCustomerId(int customerId);
        ICollection<LinkedVehiclesDTO> GetLinkedVehicleByEmployeeId(int employeeId);
        LinkedVehiclesDTO GetLinkedVehicleById(int id);
        LinkedVehiclesDTO GetLinkedVehicleByIdWithServices(int id);
        LinkedVehiclesDTO GetLinkedVehicleByLicensePlate(string licensePlate);
        ICollection<LinkedVehiclesDTO> GetLinkedVehicleByModelID(int model);
        ICollection<LinkedVehiclesDTO> GetAllLinkedVehiclesById(int id);
        void UpdateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO);
        void DeleteLinkedVehicle(int linkedVehicleId);
    }
}
