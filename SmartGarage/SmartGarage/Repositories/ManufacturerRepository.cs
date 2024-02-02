using Microsoft.EntityFrameworkCore;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly GarageContext _dbcontext;
        public ManufacturerRepository(GarageContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Manufacturer CreateManufacturer(Manufacturer manufacturer)
        {
            _dbcontext.Manufacturers.Add(manufacturer);
            _dbcontext.SaveChanges();
            return manufacturer;
        }
        public Manufacturer GetManufacturerById(int id) 
        {
            return _dbcontext.Manufacturers.FirstOrDefault(x => x.ManufacturerID== id);
        } 
        public Manufacturer GetManufacturerByName(string name) 
        {
            return _dbcontext.Manufacturers.FirstOrDefault(x => x.BrandName == name);
        }
        public ICollection<Manufacturer> GetAllManufacturers()
        {
            return _dbcontext.Manufacturers.ToList();
        }
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _dbcontext.SaveChanges();
        }

    }
}
