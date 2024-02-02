using Microsoft.AspNetCore.Mvc;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelDataService _carModelService;

        public CarModelController(ICarModelDataService carModelService)
        {
            _carModelService = carModelService ?? throw new ArgumentNullException(nameof(carModelService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarModel>> GetAllCarModels()
        {
            var carModels = _carModelService.GetAllCarModels();
            return Ok(carModels);
        }

        // api/CarModel/5
        [HttpGet("{id}")]
        public ActionResult<CarModel> GetCarModelById(int id)
        {
            var carModel = _carModelService.GetCarModelById(id);
            if (carModel == null)
            {
                return NotFound();
            }

            return Ok(carModel);
        }

        // api/CarModel
        [HttpPost]
        public ActionResult<CarModel> CreateCarModel([FromBody] CarModel carModel)
        {
            if (carModel == null)
            {
                return BadRequest();
            }

            try
            {
                var createdCarModel = _carModelService.CreateCarModel(carModel);
                return CreatedAtAction(nameof(GetCarModelById), new { id = createdCarModel.CarModelID }, createdCarModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // api/CarModel/5
        [HttpPut("{id}")]
        public IActionResult UpdateCarModel(int id, [FromBody] CarModel carModel)
        {
            if (carModel == null || id != carModel.CarModelID)
            {
                return BadRequest();
            }

            try
            {
                _carModelService.UpdateCarModel(carModel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
