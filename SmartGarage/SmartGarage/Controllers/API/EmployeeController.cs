using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDataService _employeeService;

        public EmployeeController(IEmployeeDataService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        // api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeByID(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // api/Employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var createdEmployee = _employeeService.CreateEmployee(employeeDTO);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeID }, createdEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // api/Employee/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null || id != employeeDTO.EmployeeID)
            {
                return BadRequest();
            }

            try
            {
                _employeeService.UpdateEmployee(employeeDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
