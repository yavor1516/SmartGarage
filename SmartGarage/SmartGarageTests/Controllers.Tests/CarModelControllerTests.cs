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
    public class CarModelControllerTests
    {
        private CarModelController _controller;
        private Mock<ICarModelDataService> _mockCarModelService;

        [TestInitialize]
        public void Setup()
        {
            _mockCarModelService = new Mock<ICarModelDataService>();
            _controller = new CarModelController(_mockCarModelService.Object);
        }

        [TestMethod]
        public void CreateCarModel_NullModel_ReturnsBadRequestResult()
        {
            // Act
            var result = _controller.CreateCarModel(null);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateCarModel_ValidModel_ReturnsOkResult()
        {
            // Arrange
            int id = 1;
            var carModelDTO = new CarModelDTO { CarModelID = id, Model = "Model X" };

            // Act
            var result = _controller.UpdateCarModel(id, carModelDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void UpdateCarModel_NullModel_ReturnsBadRequestResult()
        {
            // Arrange
            int id = 1;

            // Act
            var result = _controller.UpdateCarModel(id, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateCarModel_InvalidId_ReturnsBadRequestResult()
        {
            // Arrange
            int id = 1;
            var carModelDTO = new CarModelDTO { CarModelID = 2, Model = "Model X" };

            // Act
            var result = _controller.UpdateCarModel(id, carModelDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
