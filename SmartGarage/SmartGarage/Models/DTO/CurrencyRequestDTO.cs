using Microsoft.AspNetCore.Mvc;

namespace SmartGarage.Models.DTO
{
    public class CurrencyRequestDTO
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
