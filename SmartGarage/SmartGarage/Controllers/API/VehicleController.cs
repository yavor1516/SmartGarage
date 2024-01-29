using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Responses;
using SmartGarage.Services.Contracts;
using System.Security.Claims;
using System.Text;

namespace SmartGarage.Controllers.API
{
   
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleDataService _vehicleDataService;
        public VehicleController(IVehicleDataService vehicleDataService)
        {
            _vehicleDataService = vehicleDataService;
        }
        [HttpGet("Vehicles")]
        public IActionResult GetAllVehicles()
        {
            Vehicle vehicle = _vehicleDataService.GetVehicleById(1);



            return Ok(new VehicleResponse()
            {
                VehicleBrand = vehicle.Manufacturer.BrandName,
                VehicleModel = vehicle.CarModel.Model
            });
        }

        //TODO
        [HttpPost("CreateVehicle")]
        public IActionResult CreateVehicle([FromBody] VehicleDTO vehicleDTO)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = ModelState.Values.SelectMany(u => u.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse(errorMessages));
            }

            try
            {
                if (_vehicleDataService.GetVehiclesByManufacturer(vehicleDTO.Manufacturer.BrandName) != null)
                {

                    if(_vehicleDataService.GetVehicleByModel(vehicleDTO.CarModel.Model) != null)
                    {
                        Vehicle vehicle = new Vehicle()
                        {
                            Manufacturer = vehicleDTO.Manufacturer,
                            CarModel = vehicleDTO.CarModel
                        };
                        _vehicleDataService.CreateVehicle(vehicle);
                        return Ok();
                    }
                    return BadRequest();

                }


                return BadRequest();

            }

            catch (DuplicateEntityException e)
            {
                return Conflict(new ErrorResponse(e.Message));
            }

        }
    }
}
