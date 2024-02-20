using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers;
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
    public class LinkedVehiclesControllerTests
    {
        private LinkedVehiclesController _controller;
        private Mock<ILinkedVehiclesDataService> _mockLinkedVehiclesService;

        [TestInitialize]
        public void Setup()
        {
            _mockLinkedVehiclesService = new Mock<ILinkedVehiclesDataService>();
            //_controller = new LinkedVehiclesController(_mockLinkedVehiclesService.Object);
        }

        [TestMethod]
        public void GetLinkedVehicleById_ExistingId_ReturnsOkResultWithLinkedVehicle()
        {
            // Arrange
            var id = 1;
            var linkedVehicleDTO = new LinkedVehiclesDTO { /* fill with valid data */ };
            _mockLinkedVehiclesService.Setup(service => service.GetLinkedVehicleByIdWithServices(id)).Returns(linkedVehicleDTO);

            // Act
            var result = _controller.GetLinkedVehicleById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetLinkedVehicleById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 999;
            _mockLinkedVehiclesService.Setup(service => service.GetLinkedVehicleByIdWithServices(id)).Returns((LinkedVehiclesDTO)null);

            // Act
            var result = _controller.GetLinkedVehicleById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UpdateLinkedVehicle_ValidLinkedVehicle_ReturnsNoContentResult()
        {
            // Arrange
            var linkedVehiclesDTO = new LinkedVehiclesDTO { /* fill with valid data */ };

            // Act
            var result = _controller.UpdateLinkedVehicle(linkedVehiclesDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void UpdateLinkedVehicle_NullLinkedVehicle_ReturnsBadRequestResult()
        {
            // Act
            var result = _controller.UpdateLinkedVehicle(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
