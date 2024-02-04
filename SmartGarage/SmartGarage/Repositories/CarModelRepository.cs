using Castle.Core.Resource;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly GarageContext _dbcontext;

        public CarModelRepository(GarageContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public CarModel CreateCarModel(CarModel carModel)
        {
            _dbcontext.CarModels.Add(carModel);
            _dbcontext.SaveChanges();
            return carModel;
        }

        public ICollection<CarModel> GetAllCarModels()
        {
            return _dbcontext.CarModels.ToList();
        }

        public CarModel GetCarModelById(int id)
        {
            CarModel carModel = _dbcontext.CarModels.FirstOrDefault(x => x.CarModelID == id);
            return carModel;
        }

        public CarModel GetCarModelByManufacturerID(int manufacturerID)
        {
            CarModel carModel = _dbcontext.CarModels.FirstOrDefault(x => x.ManufacturerID == manufacturerID);
            return carModel;
        }

        public CarModel GetCarModelByModel(string model)
        {
            CarModel carModel = _dbcontext.CarModels.FirstOrDefault(x => x.Model == model);
            return carModel;
        }

        public CarModel GetCarModelByManufacturer(Manufacturer manufacturer)
        {
            CarModel carModel = _dbcontext.CarModels.FirstOrDefault(x => x.Manufacturer == manufacturer);
            return carModel;
        }

        public void UpdateCarModel(CarModel carModel)
        {
            var existingService = _dbcontext.CarModels.FirstOrDefault(s => s.CarModelID == carModel.CarModelID);
            if (existingService != null)
            {
                existingService.Model = carModel.Model;
                existingService.ManufacturerID = carModel.ManufacturerID;
                _dbcontext.SaveChanges(); 
            }
        }
    }
}
