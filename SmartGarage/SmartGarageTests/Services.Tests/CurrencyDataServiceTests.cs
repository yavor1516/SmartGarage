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

       
    }
}
