using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface ILinkedVehiclesDataService
    {
        LinkedVehiclesDTO CreateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO);
        LinkedVehiclesDTO GetLinkedVehicleByCustomerId(int customerId);
        LinkedVehiclesDTO GetLinkedVehicleByCustomerName(string customerName);
        LinkedVehiclesDTO GetLinkedVehicleByEmployeeId(int employeeId);
        LinkedVehiclesDTO GetLinkedVehicleByEmployeeName(string employeeName);
        LinkedVehiclesDTO GetLinkedVehicleById(int id);
        LinkedVehiclesDTO GetLinkedVehicleByLicensePlate(string licensePlate);
        LinkedVehiclesDTO GetLinkedVehicleByModelName(string model);
        ICollection<LinkedVehiclesDTO> GetAllLinkedVehiclesById(int id);
        void UpdateLinkedVehicle(LinkedVehiclesDTO linkedVehiclesDTO);
    }
}
