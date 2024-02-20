using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [Route("api/customers")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerDataService _customerDataService;

        public CustomersController(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        [HttpPost]
        public ActionResult<CustomerDTO> CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            try                                //UserID TODO
            {
                if (customerDTO == null)
                {
                    return BadRequest("Invalid customer data provided.");
                }
                var createdCustomer = _customerDataService.CreateCustomer(customerDTO);
                return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerID }, createdCustomer);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<ICollection<CustomerDTO>> GetAllCustomers()
        {
            return Ok(_customerDataService.GetAllCustomers());
        }

        [HttpGet("{email}/email")]
        public ActionResult<CustomerDTO> GetCustomerByEmail(string email)
        {
            try
            {
                var customer = _customerDataService.GetCustomerByEmail(email);
                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{firstName}/firstname")]
        public ActionResult<CustomerDTO> GetCustomerByFirstName(string firstName)
        {
            try
            {
                var customer = _customerDataService.GetCustomerByFirstName(firstName);
                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetCustomerById(int id)
        {
            try
            {
                var customer = _customerDataService.GetCustomerById(id);
                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{username}/username")]
        public ActionResult<CustomerDTO> GetCustomerByUsername(string username)
        {
            try
            {
                var customer = _customerDataService.GetCustomerByUsername(username);
                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{customerId}/linkedvehicles")]
        public IActionResult GetLinkedVehicles(int customerId)
        {
            try
            {
                var customer = _customerDataService.GetCustomerById(customerId);

                if (customer == null)
                {
                    return NotFound();
                }

                if (customer.LinkedVehicles == null || customer.LinkedVehicles.Count == 0)
                {
                    return NoContent();
                }

                return Ok(customer.LinkedVehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("CustomerDTO cannot be null");
            }
            try
            {
                _customerDataService.UpdateCustomer(customerDTO);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
