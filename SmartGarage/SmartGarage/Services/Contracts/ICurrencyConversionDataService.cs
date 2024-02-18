using System.Threading.Tasks;
namespace SmartGarage.Services.Contracts
{
    public interface ICurrencyConversionDataService
    {
        decimal ConvertCurrency(string fromCurrency, string toCurrency, decimal amount);
    }
}

