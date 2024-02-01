namespace SmartGarage.Services.Contracts
{
    public interface ILinkeeVehiclesDataService
    {
        LinkedVehicles CreateLinkedVehicle(LinkedVehicles linkedVehicles);
        LinkedVehicles GetLinkedVehicleByCustomerId(int customerId);
        LinkedVehicles GetLinkedVehicleByCustomerName(string customerName);
        LinkedVehicles GetLinkedVehicleByEmployeeId(int employeeId);
        LinkedVehicles GetLinkedVehicleByEmployeeName(string employeeName);
        LinkedVehicles GetLinkedVehicleById(int id);
        LinkedVehicles GetLinkedVehicleByLicensePlate(string licensePlate);
        LinkedVehicles GetLinkedVehicleByModelName(string model);
        ICollection<LinkedVehicles> GetAllLinkedVehiclesById(int id);
        void UpdateLinkedVehicle(LinkedVehicles linkedVehicles);
    }
}
