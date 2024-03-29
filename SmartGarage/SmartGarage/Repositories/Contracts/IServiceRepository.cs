﻿using System.Diagnostics.CodeAnalysis;

namespace SmartGarage.Repositories.Contracts
{
    public interface IServiceRepository
    {
        public Service GetServiceByID(int id);
        public Service GetServiceByName(string Name);
        public Service GetServiceByPrice(decimal Price);
        public ICollection<Service> GetAllServicesById(int id);
        public ICollection<Service> GetAllServices();
        public Service CreateService(Service service);
        public void UpdateService(Service service);

    }
}
