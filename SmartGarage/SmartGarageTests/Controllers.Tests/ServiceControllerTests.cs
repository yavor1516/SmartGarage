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
    public class ServiceControllerTests
    {
        private ServiceController _controller;
        private Mock<IServiceDataService> _mockServiceService;

        [TestInitialize]
        public void Setup()
        {
            _mockServiceService = new Mock<IServiceDataService>();
            _controller = new ServiceController(_mockServiceService.Object);
        }

        [TestMethod]
        public void UpdateService_NullService_ReturnsBadRequestResult()
        {
            // Act
            var result = _controller.UpdateService(1, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateService_InvalidServiceId_ReturnsBadRequestResult()
        {
            // Arrange
            var id = 999;
            var serviceDTO = new ServiceDTO { /* fill with valid data */ };

            // Act
            var result = _controller.UpdateService(id, serviceDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
