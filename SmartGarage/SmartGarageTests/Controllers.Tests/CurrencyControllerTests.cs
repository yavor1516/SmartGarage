using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers.API;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Controllers.Tests
{
    [TestClass]
    public class CurrencyConversionControllerTests
    {
        private CurrencyConversionController _controller;
        private Mock<ICurrencyConversionDataService> _mockCurrencyConversionService;

        [TestInitialize]
        public void Setup()
        {
            _mockCurrencyConversionService = new Mock<ICurrencyConversionDataService>();
            _controller = new CurrencyConversionController(_mockCurrencyConversionService.Object);
        }

        [TestMethod]
        public void ConvertCurrency_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var currencyRequestDTO = new CurrencyRequestDTO
            {
                FromCurrency = "USD",
                ToCurrency = "EUR",
                Amount = 100
            };
            decimal expectedConvertedAmount = 120.00M; // Assuming the conversion service returns 120.00 as decimal
            _mockCurrencyConversionService.Setup(service => service.ConvertCurrency(currencyRequestDTO.FromCurrency, currencyRequestDTO.ToCurrency, currencyRequestDTO.Amount))
                .Returns(expectedConvertedAmount);

            // Act
            var result = _controller.ConvertCurrency(currencyRequestDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedConvertedAmount, okResult.Value); // Asserting the converted amount
        }
    }
}
