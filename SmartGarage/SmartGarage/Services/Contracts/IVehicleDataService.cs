namespace SmartGarage.Services.Contracts
{
    public interface IVehicleDataService
    {
        Vehicle CreateVehicle(Vehicle vehicle);
        ICollection<Vehicle> GetVehicles();
        ICollection<Vehicle> GetAllVehiclesByEmployeeID(int employeeId);
        Vehicle GetVehicleById(int vehicleId);
        ICollection<Vehicle> GetVehiclesByManufacturer(string manufacturer);
        Vehicle GetVehicleByModel(string model);
        void UpdateVehicle(Vehicle vehicle);
    }
}
