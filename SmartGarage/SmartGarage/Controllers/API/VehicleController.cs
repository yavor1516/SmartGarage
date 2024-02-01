using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Helpers;
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
        public async Task<IActionResult> GetAllVehicles()
        {
            Vehicle vehicle = _vehicleDataService.GetVehicleByID(2);

            RandomPasswordGenerator randomPasswordGenerator = new RandomPasswordGenerator();
            
            EmailSender emailSender = new EmailSender();
            emailSender.SendEmail("milen316@gmail.com", randomPasswordGenerator.GeneratePassword(9));

           var response = new VehicleResponse()
            {
                VehicleBrand = vehicle.Manufacturer.BrandName,
                VehicleModel = vehicle.CarModel.Model
            };
            return Ok(response);
        }


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
