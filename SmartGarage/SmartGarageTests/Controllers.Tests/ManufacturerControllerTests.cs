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
    public class ManufacturerControllerTests
    {
        private ManufacturerController _controller;
        private Mock<IManufacturerDataService> _mockManufacturerService;

        [TestInitialize]
        public void Setup()
        {
            _mockManufacturerService = new Mock<IManufacturerDataService>();
            _controller = new ManufacturerController(_mockManufacturerService.Object);
        }

        [TestMethod]
        public void UpdateManufacturer_ValidManufacturer_ReturnsOkResultWithUpdatedManufacturer()
        {
            // Arrange
            var id = 1;
            var manufacturerDTO = new ManufacturerDTO { /* fill with valid data */ };

            // Act
            var result = _controller.UpdateManufacturer(id, manufacturerDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
