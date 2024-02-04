using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface ICarModelDataService
    {
        CarModelDTO CreateCarModel(CarModelDTO carModelDTO);
        ICollection<CarModelDTO> GetAllCarModels();
        CarModelDTO GetCarModelById(int id);
        CarModelDTO GetCarModelByManufacturerID(int manufacturerID);
        CarModelDTO GetCarModelByModel(string model);
        CarModelDTO GetCarModelByManufacturer(ManufacturerDTO manufacturerDTO);
        void UpdateCarModel(CarModelDTO carModelDTO);
    }
}
