using Microsoft.Extensions.Configuration;
using Moq;
using SmartGarage.Models;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class CurrencyConversionDataServiceTests
    {
        private Mock<IConfiguration> _configurationMock;
        private CurrencyConversionDataService _currencyConversionDataService;

        [TestInitialize]
        public void Setup()
        {
            _configurationMock = new Mock<IConfiguration>();
            _currencyConversionDataService = new CurrencyConversionDataService(_configurationMock.Object);
        }

        [TestMethod]
        public void ConvertCurrency_ValidInput_ReturnsCorrectConversion()
        {
            // Arrange
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            decimal amount = 100;
            string exchangeRate = "{\"USD_EUR\":1.2}";
            _configurationMock.Setup(c => c.GetValue<string>("FreeCurrencyAPI:ApiKey")).Returns("test-api-key");
            var currencyAPI = new Mock<CurrencyAPI>();
            currencyAPI.Setup(api => api.GetExchangeRate(fromCurrency, toCurrency)).Returns(exchangeRate);
            var formattedRate = _currencyConversionDataService.FormatCurrency(exchangeRate);
            var expectedConversion = decimal.Parse(formattedRate) * amount;

            // Act
            var result = _currencyConversionDataService.ConvertCurrency(fromCurrency, toCurrency, amount);

            // Assert
            Assert.AreEqual(expectedConversion, result);
        }

        [TestMethod]
        public void FormatCurrency_ValidExchangeRate_ReturnsFormattedRate()
        {
            // Arrange
            string exchangeRate = "{\"USD_EUR\":1.2}";
            string expectedFormattedRate = "1.2";

            // Act
            var result = _currencyConversionDataService.FormatCurrency(exchangeRate);

            // Assert
            Assert.AreEqual(expectedFormattedRate, result);
        }

        [TestMethod]
        public void FormatCurrency_InvalidExchangeRate_ThrowsArgumentException()
        {
            // Arrange
            string invalidExchangeRate = "{\"USD_EUR\":1.2";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _currencyConversionDataService.FormatCurrency(invalidExchangeRate));
        }
    }
}
