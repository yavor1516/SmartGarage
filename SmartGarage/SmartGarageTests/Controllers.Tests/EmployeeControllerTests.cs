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
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeDataService> _mockEmployeeService;

        [TestInitialize]
        public void Setup()
        {
            _mockEmployeeService = new Mock<IEmployeeDataService>();
            _controller = new EmployeeController(_mockEmployeeService.Object);
        }

        [TestMethod]
        public void UpdateEmployee_ValidEmployee_ReturnsNoContentResult()
        {
            // Arrange
            var id = 1;
            var employeeDTO = new EmployeeDTO { EmployeeID = id /* fill with valid data */ };

            // Act
            var result = _controller.UpdateEmployee(id, employeeDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void UpdateEmployee_NullEmployee_ReturnsBadRequestResult()
        {
            // Act
            var result = _controller.UpdateEmployee(1, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateEmployee_InvalidId_ReturnsBadRequestResult()
        {
            // Arrange
            var id = 1; // Assuming the ID doesn't match the employeeDTO
            var employeeDTO = new EmployeeDTO { EmployeeID = id + 1 /* fill with valid data */ };

            // Act
            var result = _controller.UpdateEmployee(id, employeeDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
