using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Service> GetServiceById(int id)
        {
            var service = _serviceService.GetServiceById(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // api/Service
        [HttpPost]
        public ActionResult<Service> CreateService([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest();
            }

            try
            {
                var createdService = _serviceService.CreateService(service);
                return CreatedAtAction(nameof(GetServiceById), new { id = createdService.ServiceId }, createdService);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // api/Service/5
        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, [FromBody] Service service)
        {
            if (service == null || id != service.ServiceId)
            {
                return BadRequest();
            }

            try
            {
                _serviceService.UpdateService(service);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
