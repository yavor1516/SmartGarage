using Microsoft.AspNetCore.Mvc;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
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
        public ActionResult<Manufacturer> CreateManufacturer([FromBody] ManufacturerDTO manufacturerDTO)
        {
            if (manufacturerDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var createdManufacturer = _manufacturerService.CreateManufacturer(manufacturerDTO);
                return CreatedAtAction(nameof(GetManufacturerById), new { id = createdManufacturer.ManufacturerID }, createdManufacturer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/Manufacturer/5
        [HttpPut("{id}")]
        public IActionResult UpdateManufacturer(int id,[FromBody] ManufacturerDTO manufacturerDTO)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound("Invalid Manufacturer ID");
                }
                manufacturerDTO.ManufacturerID = id;
                _manufacturerService.UpdateManufacturer(manufacturerDTO);
                return Ok(manufacturerDTO);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
