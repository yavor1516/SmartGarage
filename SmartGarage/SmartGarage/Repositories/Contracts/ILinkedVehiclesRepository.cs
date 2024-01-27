namespace SmartGarage.Repositories.Contracts
{
    public interface ILinkedVehiclesRepository
    {
        public LinkedVehicles CreateLinkedVehicle(LinkedVehicles linkedVehicles);
        public void UpdateLinkedVehicle(LinkedVehicles linkedVehicles);
        public LinkedVehicles GetLinkedVehiclesById(int id);
        public LinkedVehicles GetLinkedVehiclesByEmployeeId(int employeeId);
        public LinkedVehicles GetLinkedVehiclesByEmployeeName(string employeeName);
        public LinkedVehicles GetLinkedVehiclesByCustomerId(int customerId);
        public LinkedVehicles GetLinkedVehiclesByCustomerName(string customerName);
        public LinkedVehicles GetLinkedVehiclesByModelName(string model); 
        public LinkedVehicles GetLinkedVehiclesByLicensePlate(string licensePlate);
        public ICollection<LinkedVehicles> GetAllLinkedVehiclesById(int id);
        public void UpdateLinkedVehicles(LinkedVehicles linkedVehicles);
    }
}
