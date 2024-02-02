using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class ManufacturerDataService : IManufacturerDataService 
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerDataService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public Manufacturer CreateManufacturer(Manufacturer manufacturer)
        {
            // Add any pre-creation business logic or validation here
            if (manufacturer == null)
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }

            // Check for any business rules, e.g., if the manufacturer already exists
            // if (_manufacturerRepository.GetManufacturerByName(manufacturer.BrandName) != null)
            // {
            //     throw new InvalidOperationException("Manufacturer already exists.");
            // }

            return _manufacturerRepository.CreateManufacturer(manufacturer);
        }

        public Manufacturer GetManufacturerById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            return _manufacturerRepository.GetManufacturerById(id);
        }

        public Manufacturer GetManufacturerByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            }
            return _manufacturerRepository.GetManufacturerByName(name);
        }

        public ICollection<Manufacturer> GetAllManufacturers()
        {
            return _manufacturerRepository.GetAllManufacturers();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }

             var existingManufacturer = _manufacturerRepository.GetManufacturerById(manufacturer.ManufacturerID);
             if (existingManufacturer == null)
             {
                 throw new InvalidOperationException("Manufacturer does not exist.");
             }

            _manufacturerRepository.UpdateManufacturer(manufacturer);
        }
    }
}
