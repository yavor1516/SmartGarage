using Microsoft.EntityFrameworkCore.Query.Internal;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly GarageContext _dbcontext;
        public ServiceRepository(GarageContext dbcontext)
        {            
            _dbcontext = dbcontext;
        }
        public Service GetServiceById(int id)
        {
            return _dbcontext.Services.FirstOrDefault(x=>x.ServiceId == id);
        }
        public Service GetServiceByName(string name)
        {
            return _dbcontext.Services.FirstOrDefault(x=>x.Name == name);
        }
        public Service GetServiceByPrice(decimal Price)
        {
            return _dbcontext.Services.FirstOrDefault(x=>x.Price == Price);
        }
        public ICollection<Service> GetAllServicesById(int id) 
        {
            return _dbcontext.Services.Where(x=>x.ServiceId == id).ToList();
        }
        public ICollection<Service> GetAllServices()
        {
            return _dbcontext.Services.ToList();
        }
        public Service CreateService(Service service)
        {
            _dbcontext.Services.Add(service);
            _dbcontext.SaveChanges();
            return service;
        }
        public void UpdateService(Service service)
        {
            _dbcontext.SaveChanges();
        }


    }
}
