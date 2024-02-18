using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConversionController : ControllerBase
    {
        private readonly ICurrencyConversionDataService _currencyConversionService;

        public CurrencyConversionController(ICurrencyConversionDataService currencyConversionService)
        {
            _currencyConversionService = currencyConversionService;
        }
        
        [HttpPost("convert")]
        public IActionResult ConvertCurrency([FromBody]CurrencyRequestDTO currencyRequestDTO)
        {
            var convertedAmount = _currencyConversionService.ConvertCurrency(currencyRequestDTO.FromCurrency,currencyRequestDTO.ToCurrency,currencyRequestDTO.Amount);
            return Ok(convertedAmount);
        }
    }
}
