using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedVehicleServiceController : ControllerBase
    {
        private readonly ILinkedVehicleServiceService _linkedVehicleServiceService;

        public LinkedVehicleServiceController(ILinkedVehicleServiceService linkedVehicleServiceService)
        {
            _linkedVehicleServiceService = linkedVehicleServiceService ?? throw new ArgumentNullException(nameof(linkedVehicleServiceService));
        }

        [HttpGet("{linkedVehicleId}/{serviceId}")]
        public async Task<ActionResult<LinkedVehicleService>> GetLinkedVehicleService(int linkedVehicleId, int serviceId)
        {
            var linkedVehicleService = await _linkedVehicleServiceService.GetLinkedVehicleServiceAsync(linkedVehicleId, serviceId);
            if (linkedVehicleService == null)
            {
                return NotFound();
            }
            return Ok(linkedVehicleService);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LinkedVehicleService>>> GetAllLinkedVehicleServices()
        {
            var linkedVehicleServices = await _linkedVehicleServiceService.GetAllLinkedVehicleServicesAsync();
            return Ok(linkedVehicleServices);
        }

        [HttpGet("{linkedVehicleId}")]
        public async Task<IActionResult> GetLinkedVehicleServicesByLinkedVehicleId(int linkedVehicleId)
        {
            try
            {
                var linkedVehicleServices = await _linkedVehicleServiceService.GetAllLinkedVehicleServicesByLinkedVehicleIdAsync(linkedVehicleId);
                return Ok(linkedVehicleServices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving linked vehicle services: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LinkedVehicleService>> AddLinkedVehicleService(LinkedVehicleService linkedVehicleService)
        {
            await _linkedVehicleServiceService.AddLinkedVehicleServiceAsync(linkedVehicleService);
            return CreatedAtAction(nameof(GetLinkedVehicleService), new { linkedVehicleId = linkedVehicleService.LinkedVehicleID,
                serviceId = linkedVehicleService.ServiceID,linkedVehicleStatus = linkedVehicleService.Status,
            }, linkedVehicleService);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLinkedVehicleService(LinkedVehicleService linkedVehicleService)
        {
            try
            {
                await _linkedVehicleServiceService.UpdateLinkedVehicleServiceAsync(linkedVehicleService);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid linked vehicle service object");
            }
        }

        [HttpDelete("{linkedVehicleId}/{serviceId}")]
        public async Task<IActionResult> RemoveLinkedVehicleService(int linkedVehicleId, int serviceId)
        {
            await _linkedVehicleServiceService.RemoveLinkedVehicleServiceAsync(linkedVehicleId, serviceId);
            return NoContent();
        }
    }
}
