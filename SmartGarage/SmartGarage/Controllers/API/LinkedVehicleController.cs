using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Exceptions;
using SmartGarage.Helpers;
using SmartGarage.Models;
using SmartGarage.Models.DTO;
using SmartGarage.Responses;
using SmartGarage.Services.Contracts;
using System.Security.Claims;
using System.Text;

namespace SmartGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedVehiclesController : ControllerBase
    {
        private readonly ILinkedVehiclesDataService _linkedVehiclesDataService;

        public LinkedVehiclesController(ILinkedVehiclesDataService linkedVehiclesDataService)
        {
            _linkedVehiclesDataService = linkedVehiclesDataService ?? throw new ArgumentNullException(nameof(linkedVehiclesDataService));
        }

        [HttpPost]
        public ActionResult<LinkedVehiclesDTO> CreateLinkedVehicle([FromBody] LinkedVehiclesDTO linkedVehiclesDTO)
        {
            if (linkedVehiclesDTO == null)
                return BadRequest();

            var createdLinkedVehicle = _linkedVehiclesDataService.CreateLinkedVehicle(linkedVehiclesDTO);

            return CreatedAtAction(nameof(GetLinkedVehicleById), new { id = createdLinkedVehicle.LinkedVehicleID }
            , createdLinkedVehicle);
        }

        [HttpGet("{id}")]
        public IActionResult GetLinkedVehicleById(int id)
        {
                var linkedVehicleDto = _linkedVehiclesDataService.GetLinkedVehicleByIdWithServices(id);
                if (linkedVehicleDto == null)
                {
                    return NotFound();
                }
                return Ok(linkedVehicleDto);
            
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<LinkedVehiclesDTO> GetLinkedVehicleByCustomerId(int customerId)
        {
            var linkedVehicleDTO = _linkedVehiclesDataService.GetLinkedVehicleByCustomerId(customerId);

            if (linkedVehicleDTO == null)
                return NotFound();

            return Ok(linkedVehicleDTO);
        }


        [HttpGet("employee/{employeeId}")]
        public ActionResult<LinkedVehiclesDTO> GetLinkedVehicleByEmployeeId(int employeeId)
        {
            var linkedVehicleDTO = _linkedVehiclesDataService.GetLinkedVehicleByEmployeeId(employeeId);

            if (linkedVehicleDTO == null)
                return NotFound();

            return Ok(linkedVehicleDTO);
        }

        [HttpGet("licenseplate/{licensePlate}")]
        public ActionResult<LinkedVehiclesDTO> GetLinkedVehicleByLicensePlate(string licensePlate)
        {
            var linkedVehicleDTO = _linkedVehiclesDataService.GetLinkedVehicleByLicensePlate(licensePlate);

            if (linkedVehicleDTO == null)
                return NotFound();

            return Ok(linkedVehicleDTO);
        }

        [HttpGet("model/{model}")]
        public ActionResult<LinkedVehiclesDTO> GetLinkedVehicleByModelID(int model)
        {
            var linkedVehicleDTO = _linkedVehiclesDataService.GetLinkedVehicleByModelID(model);

            if (linkedVehicleDTO == null)
                return NotFound();

            return Ok(linkedVehicleDTO);
        }

        [HttpGet]
        public ActionResult<ICollection<LinkedVehiclesDTO>> GetAllLinkedVehiclesById(int id)
        {
            var linkedVehiclesDTOs = _linkedVehiclesDataService.GetAllLinkedVehiclesById(id);

            if (linkedVehiclesDTOs == null || linkedVehiclesDTOs.Count == 0)
                return NoContent();

            return Ok(linkedVehiclesDTOs);
        }

        [HttpPut]
        public IActionResult UpdateLinkedVehicle([FromBody] LinkedVehiclesDTO linkedVehiclesDTO)
        {
            if (linkedVehiclesDTO == null)
                return BadRequest();

            try
            {
                _linkedVehiclesDataService.UpdateLinkedVehicle(linkedVehiclesDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpDelete("{id}")]
        //public IActionResult DeleteLinkedVehicle(int id)
        //{
        //    if (id <= 0)
        //        return BadRequest("Invalid ID");

        //    try
        //    {
        //        _linkedVehiclesDataService.DeleteLinkedVehicle(id);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}