using Microsoft.AspNetCore.Mvc;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceDataService _invoiceDataService;

        public InvoiceController(IInvoiceDataService invoiceDataService)
        {
            _invoiceDataService = invoiceDataService;
        }

        [HttpPost("create")]
        public IActionResult CreateInvoice([FromBody] InvoiceDTO invoiceDTO)
        {
            try
            {
                var createdInvoice = _invoiceDataService.CreateInvoice(invoiceDTO);
                return CreatedAtAction(nameof(GetInvoiceById), new {id=createdInvoice.InvoiceID},createdInvoice);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _invoiceDataService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetInvoiceByEmail(string email)
        {
            try
            {
                var invoiceDTO = _invoiceDataService.GetInvoiceByEmail(email);
                return Ok(invoiceDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetInvoiceByEmployeeID(int employeeId)
        {
            var invoice = _invoiceDataService.GetInvoiceByEmployeeID(employeeId);
            return Ok(invoice);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            try
            {
                var invoiceDTO = _invoiceDataService.GetInvoiceById(id);
                return Ok(invoiceDTO);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetInvoiceByUserID(int userId)
        {
            var invoice = _invoiceDataService.GetInvoiceByUserID(userId);
            return Ok(invoice);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id,[FromBody] InvoiceDTO invoiceDTO)
        {
            try
            {
                invoiceDTO.InvoiceID = id;
                _invoiceDataService.UpdateInvoice(invoiceDTO);
                return Ok(invoiceDTO);
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
