using Microsoft.EntityFrameworkCore;
using SmartGarage.Models;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class LinkedVehicleServiceRepository : ILinkedVehicleServiceRepository
    {
        private readonly GarageContext _context;

        public LinkedVehicleServiceRepository(GarageContext context)
        {
            _context = context;
        }

        public async Task<LinkedVehicleService> GetByIdAsync(int linkedVehicleId, int serviceId)
        {
            return await _context.LinkedVehicleService
                .FirstOrDefaultAsync(lvs => lvs.LinkedVehicleID == linkedVehicleId && lvs.ServiceID == serviceId);
        }

        public async Task<IEnumerable<LinkedVehicleService>> GetAllAsync()
        {
            return await _context.LinkedVehicleService.ToListAsync();
        }

        public async Task AddAsync(LinkedVehicleService linkedVehicleService)
        {
            await _context.LinkedVehicleService.AddAsync(linkedVehicleService);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LinkedVehicleService linkedVehicleService)
        {
            _context.LinkedVehicleService.Update(linkedVehicleService);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(LinkedVehicleService linkedVehicleService)
        {
            _context.LinkedVehicleService.Remove(linkedVehicleService);
            await _context.SaveChangesAsync();
        }
    }
}
