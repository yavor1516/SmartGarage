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

namespace SmartGarage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedVehicleController : ControllerBase
    {
        private readonly ILinkedVehiclesDataService _linkedVehicleService;

        public LinkedVehicleController(ILinkedVehiclesDataService linkedVehicleService)
        {
            _linkedVehicleService = linkedVehicleService;
        }

        // GET: api/LinkedVehicle/5
        [HttpGet("{id}")]
        public ActionResult<ICollection<LinkedVehiclesDTO>> GetAllLinkedVehiclesById(int id)
        {
            var linkedVehicles = _linkedVehicleService.GetAllLinkedVehiclesById(id);
            if (linkedVehicles == null || !linkedVehicles.Any())
            {
                return NotFound();
            }

            return Ok(linkedVehicles);
        }

        // GET: api/LinkedVehicle/5
        [HttpGet("{id}")]
        public ActionResult<LinkedVehiclesDTO> GetLinkedVehicle(int id)
        {
            var linkedVehicle = _linkedVehicleService.GetLinkedVehicleById(id);

            if (linkedVehicle == null)
            {
                return NotFound();
            }

            return Ok(linkedVehicle);
        }

        // POST: api/LinkedVehicle
        [HttpPost]
        public ActionResult<LinkedVehiclesDTO> CreateLinkedVehicle(LinkedVehiclesDTO linkedVehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLinkedVehicle = _linkedVehicleService.CreateLinkedVehicle(linkedVehicleDto);
            return CreatedAtAction(nameof(GetLinkedVehicle), new { id = createdLinkedVehicle.LinkedVehiclelID }, createdLinkedVehicle);
        }

        // PUT: api/LinkedVehicle/5
        [HttpPut("{id}")]
        public IActionResult UpdateLinkedVehicle(int id, LinkedVehiclesDTO linkedVehicleDto)
        {
            if (id != linkedVehicleDto.LinkedVehiclelID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _linkedVehicleService.UpdateLinkedVehicle(linkedVehicleDto);
            return NoContent();
        }

        // DELETE: api/LinkedVehicle/5
        /*[HttpDelete("{id}")]
        public IActionResult DeleteLinkedVehicle(int id)
        {
            var linkedVehicle = _linkedVehicleService.GetLinkedVehicleById(id);
            if (linkedVehicle == null)
            {
                return NotFound();
            }

            _linkedVehicleService.DeleteLinkedVehicle(id);
            return NoContent();
        }*/
    }
}