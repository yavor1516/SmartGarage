using freecurrencyapi;

namespace SmartGarage.Models
{
    public class CurrencyAPI
    {
        private readonly Freecurrencyapi apiKey;
        public CurrencyAPI()
        {
            apiKey = new Freecurrencyapi("fca_live_i8sVk96Oky3exKJpgPsVcFg1kIwRv4ZquyBrHBY7");
        }

        /*bool CheckQuota()
        {
            var status = apiKey.Status();
            // trqbva da se deserializira, zashtoto nai-veroqtno vrushta json
            // if status is ok and you have quota return true
        }*/
        public string USDtoAllCurrencies()
        {            
           return apiKey.Latest("USD","BGN");
        }
        public string GetExchangeRate(string fromCurrency, string toCurrency)
        {
            return apiKey.Latest(fromCurrency, toCurrency);
        }
    }
}
