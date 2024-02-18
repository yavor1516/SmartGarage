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
    public class VehicleControllerTests
    {
        private VehicleController _controller;
        private Mock<IVehicleDataService> _mockVehicleService;

        [TestInitialize]
        public void Setup()
        {
            _mockVehicleService = new Mock<IVehicleDataService>();
            _controller = new VehicleController(_mockVehicleService.Object);
        }

        [TestMethod]
        public void CreateVehicle_NullVehicle_ReturnsBadRequestResult()
        {
            // Act
            var result = _controller.CreateVehicle(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
