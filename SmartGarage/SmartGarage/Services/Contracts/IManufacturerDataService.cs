namespace SmartGarage.Services.Contracts
{
    public interface IManufacturerDataService
    {
        Manufacturer CreateManufacturer(Manufacturer manufacturer);
        Manufacturer GetManufacturerById(int id);
        Manufacturer GetManufacturerByName(string name);
        ICollection<CarModel> GetAllCarModels();
        void UpdateManufacturer(Manufacturer manufacturer);
    }
}
