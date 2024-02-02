using Microsoft.AspNetCore.Mvc;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerDataService _manufacturerService;

        public ManufacturerController(IManufacturerDataService manufacturerService)
        {
            _manufacturerService = manufacturerService ?? throw new ArgumentNullException(nameof(manufacturerService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            var manufacturers = _manufacturerService.GetAllManufacturers();
            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public ActionResult<Manufacturer> GetManufacturerById(int id)
        {
            var manufacturer = _manufacturerService.GetManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        [HttpPost]
        public ActionResult<Manufacturer> CreateManufacturer([FromBody] Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return BadRequest();
            }

            try
            {
                var createdManufacturer = _manufacturerService.CreateManufacturer(manufacturer);
                return CreatedAtAction(nameof(GetManufacturerById), new { id = createdManufacturer.ManufacturerID }, createdManufacturer);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., validation errors) and return an appropriate response
                return BadRequest(ex.Message);
            }
        }

        //api/Manufacturer/5
        [HttpPut("{id}")]
        public IActionResult UpdateManufacturer(int id, [FromBody] Manufacturer manufacturer)
        {
            if (manufacturer == null || id != manufacturer.ManufacturerID)
            {
                return BadRequest();
            }

            try
            {
                _manufacturerService.UpdateManufacturer(manufacturer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
