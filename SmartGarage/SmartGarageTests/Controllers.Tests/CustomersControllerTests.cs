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
    public class CustomersControllerTests
    {
        private CustomersController _controller;
        private Mock<ICustomerDataService> _mockCustomerDataService;

        [TestInitialize]
        public void Setup()
        {
            _mockCustomerDataService = new Mock<ICustomerDataService>();
            //_controller = new CustomersController(_mockCustomerDataService.Object);
        }

        [TestMethod]
        public void GetAllCustomers_ReturnsOkResultWithCustomerList()
        {
            // Arrange
            var customers = new List<CustomerDTO> { new CustomerDTO { /* fill with valid data */ } };
            _mockCustomerDataService.Setup(service => service.GetAllCustomers()).Returns(customers);

            // Act
            var result = _controller.GetAllCustomers();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<CustomerDTO>));
        }

        [TestMethod]
        public void GetCustomerByEmail_ValidEmail_ReturnsOkResultWithCustomer()
        {
            // Arrange
            var email = "test@example.com";
            var customer = new CustomerDTO { /* fill with valid data */ };
            _mockCustomerDataService.Setup(service => service.GetCustomerByEmail(email)).Returns(customer);

            // Act
            var result = _controller.GetCustomerByEmail(email);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(customer, okResult.Value);
        }

        [TestMethod]
        public void GetCustomerByEmail_InvalidEmail_ReturnsNotFoundResult()
        {
            // Arrange
            var email = "invalid@example.com";
            _mockCustomerDataService.Setup(service => service.GetCustomerByEmail(email)).Returns((CustomerDTO)null);

            // Act
            var result = _controller.GetCustomerByEmail(email);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCustomerByFirstName_ValidFirstName_ReturnsOkResultWithCustomer()
        {
            // Arrange
            var firstName = "John";
            var customer = new CustomerDTO { /* fill with valid data */ };
            _mockCustomerDataService.Setup(service => service.GetCustomerByFirstName(firstName)).Returns(customer);

            // Act
            var result = _controller.GetCustomerByFirstName(firstName);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(customer, okResult.Value);
        }

        [TestMethod]
        public void GetCustomerByFirstName_InvalidFirstName_ReturnsNotFoundResult()
        {
            // Arrange
            var firstName = "Nonexistent";
            _mockCustomerDataService.Setup(service => service.GetCustomerByFirstName(firstName)).Returns((CustomerDTO)null);

            // Act
            var result = _controller.GetCustomerByFirstName(firstName);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCustomerById_ValidId_ReturnsOkResultWithCustomer()
        {
            // Arrange
            var id = 1;
            var customer = new CustomerDTO { /* fill with valid data */ };
            _mockCustomerDataService.Setup(service => service.GetCustomerById(id)).Returns(customer);

            // Act
            var result = _controller.GetCustomerById(id);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(customer, okResult.Value);
        }

        [TestMethod]
        public void GetCustomerById_InvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 999; // Assuming the customer with this ID doesn't exist
            _mockCustomerDataService.Setup(service => service.GetCustomerById(id)).Returns((CustomerDTO)null);

            // Act
            var result = _controller.GetCustomerById(id);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetCustomerByUsername_ValidUsername_ReturnsOkResultWithCustomer()
        {
            // Arrange
            var username = "testuser";
            var customer = new CustomerDTO { /* fill with valid data */ };
            _mockCustomerDataService.Setup(service => service.GetCustomerByUsername(username)).Returns(customer);

            // Act
            var result = _controller.GetCustomerByUsername(username);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            Assert.AreEqual(customer, okResult.Value);
        }

        [TestMethod]
        public void GetCustomerByUsername_InvalidUsername_ReturnsNotFoundResult()
        {
            // Arrange
            var username = "nonexistentuser";
            _mockCustomerDataService.Setup(service => service.GetCustomerByUsername(username)).Returns((CustomerDTO)null);

            // Act
            var result = _controller.GetCustomerByUsername(username);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetLinkedVehicles_CustomerWithNoLinkedVehicles_ReturnsNoContentResult()
        {
            // Arrange
            var customerId = 1; // Assuming the customer exists but has no linked vehicles
            _mockCustomerDataService.Setup(service => service.GetCustomerById(customerId)).Returns(new CustomerDTO { /* fill with valid data */ });

            // Act
            var result = _controller.GetLinkedVehicles(customerId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void GetLinkedVehicles_CustomerNotFound_ReturnsNotFoundResult()
        {
            // Arrange
            var customerId = 999; // Assuming the customer with this ID doesn't exist
            _mockCustomerDataService.Setup(service => service.GetCustomerById(customerId)).Returns((CustomerDTO)null);

            // Act
            var result = _controller.GetLinkedVehicles(customerId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UpdateCustomer_ValidCustomer_ReturnsOkResult()
        {
            // Arrange
            var customerDTO = new CustomerDTO { /* fill with valid data */ };

            // Act
            var result = _controller.UpdateCustomer(customerDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void UpdateCustomer_NullCustomer_ReturnsBadRequestResult()
        {
            // Act
            var result = _controller.UpdateCustomer(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
