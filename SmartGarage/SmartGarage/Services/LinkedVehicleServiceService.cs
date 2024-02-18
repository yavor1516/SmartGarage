using SmartGarage.Models;
using SmartGarage.Repositories;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Services
{
    public class LinkedVehicleServiceService
    {
        private readonly ILinkedVehicleServiceRepository _repository;

        public LinkedVehicleServiceService(ILinkedVehicleServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<LinkedVehicleService> GetLinkedVehicleServiceAsync(int linkedVehicleId, int serviceId)
        {
            return await _repository.GetByIdAsync(linkedVehicleId, serviceId);
        }

        public async Task<IEnumerable<LinkedVehicleService>> GetAllLinkedVehicleServicesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddLinkedVehicleServiceAsync(LinkedVehicleService linkedVehicleService)
        {
            await _repository.AddAsync(linkedVehicleService);
        }

        public async Task UpdateLinkedVehicleServiceAsync(LinkedVehicleService linkedVehicleService)
        {
            await _repository.UpdateAsync(linkedVehicleService);
        }
        public async Task RemoveLinkedVehicleServiceAsync(int linkedVehicleId, int serviceId)
        {
            var linkedVehicleService = await _repository.GetByIdAsync(linkedVehicleId, serviceId);
            if (linkedVehicleService != null)
            {
                await _repository.RemoveAsync(linkedVehicleService);
            }
        }
    }
}
