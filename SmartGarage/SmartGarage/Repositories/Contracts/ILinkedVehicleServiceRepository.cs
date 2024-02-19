using SmartGarage.Models;

namespace SmartGarage.Repositories.Contracts
{
    public interface ILinkedVehicleServiceRepository
    {
        Task<LinkedVehicleService> GetByIdAsync(int linkedVehicleId, int serviceId);
        Task<IEnumerable<LinkedVehicleService>> GetAllAsync();
        Task AddAsync(LinkedVehicleService linkedVehicleService);
        Task UpdateAsync(LinkedVehicleService linkedVehicleService);
        Task<IEnumerable<LinkedVehicleService>> GetAllByLinkedVehicleIdAsync(int linkedVehicleId);
        Task RemoveAsync(LinkedVehicleService linkedVehicleService);
    }
}
