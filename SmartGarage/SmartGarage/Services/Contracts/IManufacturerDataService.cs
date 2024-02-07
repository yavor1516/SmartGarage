using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IManufacturerDataService
    {
        ManufacturerDTO CreateManufacturer(ManufacturerDTO manufacturerDTO);
        ManufacturerDTO GetManufacturerById(int id);
        ManufacturerDTO GetManufacturerByName(string name);
        ICollection<ManufacturerDTO> GetAllManufacturers();
        void UpdateManufacturer(ManufacturerDTO manufacturerDTO);
    }
}
