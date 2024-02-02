namespace SmartGarage.Repositories.Contracts
{
    public interface IManufacturerRepository
    {
        public Manufacturer CreateManufacturer (Manufacturer manufacturer);
        public Manufacturer GetManufacturerById(int id);
        public Manufacturer GetManufacturerByName(string name);
        public ICollection<Manufacturer> GetAllManufacturers();
        public void UpdateManufacturer(Manufacturer manufacturer);      

    }
}
