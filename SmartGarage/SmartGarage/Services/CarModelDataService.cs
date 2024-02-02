using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class CarModelDataService : ICarModelDataService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelDataService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public CarModel CreateCarModel(CarModel carModel)
        {
            if (carModel == null)
            {
                throw new ArgumentNullException(nameof(carModel));
            }

             if (_carModelRepository.GetCarModelByModel(carModel.Model) != null)
             {
                 throw new InvalidOperationException("Car model already exists.");
             }

            return _carModelRepository.CreateCarModel(carModel);
        }

        public ICollection<CarModel> GetAllCarModels()
        {
            return _carModelRepository.GetAllCarModels();
        }

        public CarModel GetCarModelById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            return _carModelRepository.GetCarModelById(id);
        }

        public CarModel GetCarModelByManufacturerID(int manufacturerID)
        {
            return _carModelRepository.GetCarModelByManufacturerID(manufacturerID);
        }

        public CarModel GetCarModelByModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Model cannot be null or whitespace.", nameof(model));
            }
            return _carModelRepository.GetCarModelByModel(model);
        }

        public CarModel GetCarModelByManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }
            return _carModelRepository.GetCarModelByManufacturer(manufacturer);
        }

        public void UpdateCarModel(CarModel carModel)
        {
            // Add any pre-update business logic or validation here
            if (carModel == null)
            {
                throw new ArgumentNullException(nameof(carModel));
            }

            // For example, ensure the car model exists
             var existingCarModel = _carModelRepository.GetCarModelById(carModel.CarModelID);
             if (existingCarModel == null)
             {
                 throw new InvalidOperationException("Car model does not exist.");
             }

            _carModelRepository.UpdateCarModel(carModel);
        }
    }
}
