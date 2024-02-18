using System;
using freecurrencyapi;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SmartGarage.Services.Contracts;
using Microsoft.Extensions.Options;
using SmartGarage.Services.FreeCurrencyApi;
using SmartGarage.Models;

namespace SmartGarage.Services
{
    public class CurrencyConversionDataService : ICurrencyConversionDataService
    {
        private readonly Freecurrencyapi _fxApi;

        public CurrencyConversionDataService(IConfiguration configuration)
        {
            var apiKey = configuration.GetValue<string>("FreeCurrencyAPI:ApiKey");
            _fxApi = new Freecurrencyapi(apiKey);
        }

        public decimal ConvertCurrency(string fromCurrency, string toCurrency, decimal amount)
        {
            var currencyAPI = new CurrencyAPI();           
            var exchangeRate = currencyAPI.GetExchangeRate(fromCurrency,toCurrency);
            var formattedCurrency = FormatCurrency(exchangeRate);
            var result = decimal.Parse(formattedCurrency) * amount;
            return result; 
           
        }

        public string FormatCurrency (string exchangeRate)
        {
            var firstIndex = exchangeRate.LastIndexOf(':');
            var lastIndex = exchangeRate.LastIndexOf("}");
            var rate = exchangeRate.Substring(firstIndex+1,lastIndex-firstIndex-2);
            return rate;
        }

    }
}



