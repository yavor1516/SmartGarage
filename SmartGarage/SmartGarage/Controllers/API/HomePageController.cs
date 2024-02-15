using Microsoft.AspNetCore.Mvc;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [ApiController]

    [Route("/home")]
    public class HomePageController : ControllerBase
    {
        private readonly IServiceDataService _serviceService;
        public HomePageController(IServiceDataService serviceService)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Ok("Welcome to the home page!");
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetAllServices()
        {
            var services = _serviceService.GetAllServices();
            return Ok(services);
        }
    }
}
