namespace SmartGarage.Repositories.Contracts
{
    public interface ICarModelRepository
    {
        public CarModel GetCarModelById(int id);
        public CarModel GetCarModelByModel(string model);
        public CarModel GetCarModelByManufacturerID(int manufacturerID);
        public CarModel GetCarModelByManufacturer(Manufacturer manufacturer);
        public ICollection<CarModel> GetAllCarModels();
        public CarModel CreateCarModel(CarModel carModel);
        public void UpdateCarModel(CarModel carModel);
    }
}
