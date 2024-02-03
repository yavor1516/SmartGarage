namespace SmartGarage.Services.Contracts
{
    public interface IManufacturerDataService
    {
        Manufacturer CreateManufacturer(Manufacturer manufacturer);
        Manufacturer GetManufacturerById(int id);
        Manufacturer GetManufacturerByName(string name);
        ICollection<Manufacturer> GetAllManufacturers();
        void UpdateManufacturer(Manufacturer manufacturer);
    }
}
