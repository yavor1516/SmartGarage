using SmartGarage.Models.DTO;
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

        public CarModelDTO CreateCarModel(CarModelDTO carModelDTO)
        {
            if (carModelDTO == null)
            {
                throw new ArgumentNullException(nameof(carModelDTO));
            }

            // Check if the car model already exists (you can implement this logic)
            if (_carModelRepository.GetCarModelByModel(carModelDTO.Model) != null)
            {
                throw new InvalidOperationException("Car model already exists.");
            }

            // Map the DTO to the entity
            var carModel = new CarModel
            {
                Model = carModelDTO.Model,
                ManufacturerID = carModelDTO.ManufacturerID
            };

            var createdCarModel = _carModelRepository.CreateCarModel(carModel);

            // Map the created entity back to DTO
            return MapCarModelToDTO(createdCarModel);
        }

        public ICollection<CarModelDTO> GetAllCarModels()
        {
            var carModels = _carModelRepository.GetAllCarModels();

            // Map the list of entities to DTOs
            return carModels.Select(MapCarModelToDTO).ToList();
        }

        public CarModelDTO GetCarModelById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var carModel = _carModelRepository.GetCarModelById(id);

            // Map the entity to DTO
            return MapCarModelToDTO(carModel);
        }

        public CarModelDTO GetCarModelByManufacturerID(int manufacturerID)
        {
            var carModel = _carModelRepository.GetCarModelByManufacturerID(manufacturerID);

            // Map the entity to DTO
            return MapCarModelToDTO(carModel);
        }

        public CarModelDTO GetCarModelByModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Model cannot be null or whitespace.", nameof(model));
            }

            var carModel = _carModelRepository.GetCarModelByModel(model);

            // Map the entity to DTO
            return MapCarModelToDTO(carModel);
        }

        public CarModelDTO GetCarModelByManufacturer(ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                throw new ArgumentNullException(nameof(manufacturerDTO));
            }

            // Map the ManufacturerDTO to the entity (you'll need to implement this mapping)
            var manufacturerEntity = MapManufacturerDTOToEntity(manufacturerDTO);

            var carModel = _carModelRepository.GetCarModelByManufacturer(manufacturerEntity);

            // Map the entity to DTO
            return MapCarModelToDTO(carModel);
        }

        public void UpdateCarModel(CarModelDTO carModelDTO)
        {
            // Add any pre-update business logic or validation here
            if (carModelDTO == null)
            {
                throw new ArgumentNullException(nameof(carModelDTO));
            }

            // Map the DTO to the entity
            var carModel = new CarModel
            {
                CarModelID = carModelDTO.CarModelID,
                Model = carModelDTO.Model,
                ManufacturerID = carModelDTO.ManufacturerID
            };

            var existingCarModel = _carModelRepository.GetCarModelById(carModel.CarModelID);
            if (existingCarModel == null)
            {
                throw new InvalidOperationException("Car model does not exist.");
            }

            _carModelRepository.UpdateCarModel(carModel);
        }

        private CarModelDTO MapCarModelToDTO(CarModel carModel)
        {
            if (carModel == null)
            {
                return null;
            }

            return new CarModelDTO
            {
                CarModelID = carModel.CarModelID,
                Model = carModel.Model,
                ManufacturerID = carModel.ManufacturerID
            };
        }

        private Manufacturer MapManufacturerDTOToEntity(ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                return null;
            }

            return new Manufacturer
            {
                ManufacturerID = manufacturerDTO.ManufacturerID,
                BrandName = manufacturerDTO.BrandName,
                CarModels = manufacturerDTO.CarModels?.Select(MapCarModelDTOToEntity).ToList(),
            };
        }
        private CarModel MapCarModelDTOToEntity(CarModelDTO carModelDTO)
        {
            return new CarModel
            {
                CarModelID = carModelDTO.CarModelID,
                Model = carModelDTO.Model,
                ManufacturerID = carModelDTO.ManufacturerID
            };
        }
    }
}
