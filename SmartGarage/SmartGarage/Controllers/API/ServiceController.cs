using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceDataService _serviceService;

        public ServiceController(IServiceDataService serviceService)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }

        // api/Service
        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetAllServices()
        {
            var services = _serviceService.GetAllServices();
            return Ok(services);
        }

        // api/Service/5
        [HttpGet("{id}")]
        public ActionResult<Service> GetServiceByID(int id)
        {
            var service = _serviceService.GetServiceByID(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // api/Service
        [HttpPost]
        public ActionResult<Service> CreateService([FromBody] ServiceDTO serviceDTO)
        {
            if (serviceDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var createdService = _serviceService.CreateService(serviceDTO);
                return CreatedAtAction(nameof(GetServiceByID), new { id = createdService.ServiceID }, createdService);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // api/Service/5
        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, [FromBody] ServiceDTO serviceDTO)
        {
            if (serviceDTO == null || id != serviceDTO.ServiceID)
            {
                return BadRequest();
            }

            try
            {
                _serviceService.UpdateService(serviceDTO);
                var updatedService = _serviceService.GetServiceByID(id);
                return Ok(updatedService);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
