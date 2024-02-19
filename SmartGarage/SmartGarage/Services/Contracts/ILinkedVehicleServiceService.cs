using SmartGarage.Models;

namespace SmartGarage.Services.Contracts
{
    public interface ILinkedVehicleServiceService
    {
        Task<LinkedVehicleService> GetLinkedVehicleServiceAsync(int linkedVehicleId, int serviceId);
        Task<IEnumerable<LinkedVehicleService>> GetAllLinkedVehicleServicesAsync();
        Task AddLinkedVehicleServiceAsync(LinkedVehicleService linkedVehicleService);
        Task UpdateLinkedVehicleServiceAsync(LinkedVehicleService linkedVehicleService);
        Task<IEnumerable<LinkedVehicleService>> GetAllLinkedVehicleServicesByLinkedVehicleIdAsync(int linkedVehicleId);
        Task RemoveLinkedVehicleServiceAsync(int linkedVehicleId, int serviceId);
    }
}
