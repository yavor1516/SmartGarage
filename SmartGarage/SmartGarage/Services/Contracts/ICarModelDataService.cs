namespace SmartGarage.Services.Contracts
{
    public interface ICarModelDataService
    {
        CarModel CreateCarModel(CarModel carModel);
        ICollection<CarModel> GetAllCarModels();
        CarModel GetCarModelById(int id);
        CarModel GetCarModelByManufacturerID(int manufacturerID);
        CarModel GetCarModelByModel(string model);
        CarModel GetCarModelByManufacturer(Manufacturer manufacturer);
        void UpdateCarModel(CarModel carModel);
    }
}
