namespace SmartGarage.Repositories.Contracts
{
    public interface ILinkedVehiclesRepository
    {
        public LinkedVehicles CreateLinkedVehicle(LinkedVehicles linkedVehicles);
        public LinkedVehicles GetLinkedVehiclesById(int id);
        public ICollection<LinkedVehicles> GetLinkedVehiclesByEmployeeId(int employeeId);
        public LinkedVehicles GetLinkedVehiclesByEmployeeName(string employeeName);
        public ICollection<LinkedVehicles> GetLinkedVehiclesByCustomerId(int customerId);
        public LinkedVehicles GetLinkedVehiclesByCustomerName(string customerName);
        public ICollection<LinkedVehicles> GetLinkedVehiclesByModelID(int model);
        public  LinkedVehicles GetLinkedVehicleByIdWithServices(int id);
        public LinkedVehicles GetLinkedVehiclesByLicensePlate(string licensePlate);
        public ICollection<LinkedVehicles> GetAllLinkedVehiclesById(int id);
        public void UpdateLinkedVehicles(LinkedVehicles linkedVehicles);
    }
}
