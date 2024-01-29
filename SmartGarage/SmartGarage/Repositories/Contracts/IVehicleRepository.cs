
namespace SmartGarage.Repositories.Contracts;

public interface IVehicleRepository
{
    
    public Vehicle GetVehicleById(int id);
    public ICollection<Vehicle> GetVehiclesByManufacturer(string Manufacturer);
    public Vehicle GetVehicleByModel(string Model);        
    public ICollection<Vehicle> GetAllVehiclesByEmployeeID(int id);
    public ICollection<Vehicle> GetAllVehicles();
    public Vehicle CreateVehicle(Vehicle vehicle);
    public void UpdateVehicle(Vehicle vehicle);

}
