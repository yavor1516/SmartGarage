using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Exceptions;
using SmartGarage.Helpers;
using SmartGarage.Models.DTO;
using SmartGarage.Responses;
using SmartGarage.Services.Contracts;
using System.Security.Claims;
using System.Text;

namespace SmartGarage.Controllers.API
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleDataService _vehicleDataService;

        public VehicleController(IVehicleDataService vehicleDataService)
        {
            _vehicleDataService = vehicleDataService;
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleDTO vehicleDTO)
        {
            try
            {
                var createdVehicle = _vehicleDataService.CreateVehicle(vehicleDTO);
                return CreatedAtRoute("GetVehicleById", new { id = createdVehicle.VehicleID }, createdVehicle);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetVehicleById")]
        public IActionResult GetVehicleById(int id)
        {
            try
            {
                var vehicleDTO = _vehicleDataService.GetVehicleByID(id);
                return Ok(vehicleDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetAllVehiclesByEmployeeID(int employeeId)
        {
            var vehicles = _vehicleDataService.GetAllVehiclesByEmployeeID(employeeId);
            return Ok(vehicles);
        }

        [HttpGet("manufacturer/{manufacturer}")]
        public IActionResult GetVehiclesByManufacturer(string manufacturer)
        {
            var vehicles = _vehicleDataService.GetVehiclesByManufacturer(manufacturer);
            return Ok(vehicles);
        }

        [HttpGet("model/{model}")]
        public IActionResult GetVehicleByModel(string model)
        {
            try
            {
                var vehicleDTO = _vehicleDataService.GetVehicleByModel(model);
                return Ok(vehicleDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            try
            {
                vehicleDTO.VehicleID = id; // Ensure the DTO has the correct ID
                _vehicleDataService.UpdateVehicle(vehicleDTO);
                return NoContent();
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

        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            var vehicles = _vehicleDataService.GetAllVehicles();
            return Ok(vehicles);
        }
    }
}
