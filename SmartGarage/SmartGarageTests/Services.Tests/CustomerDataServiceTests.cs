using Moq;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class CustomerDataServiceTests
    {
        private Mock<ICustomerRepository> _customerRepositoryMock;
        private CustomerDataService _customerDataService;

        [TestInitialize]
        public void Setup()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerDataService = new CustomerDataService(_customerRepositoryMock.Object);
        }

        [TestMethod]
        public void CreateCustomer_ValidCustomerDTO_ReturnsCreatedCustomerDTO()
        {
            // Arrange
            var customerDTO = new CustomerDTO
            {
                CustomerID = 1,
                UserID = 1,
                LinkedVehicles = new List<LinkedVehiclesDTO>()
            };
            var customerEntity = new Customer
            {
                CustomerID = 1,
                UserID = 1,
                LinkedVehicles = new List<LinkedVehicles>()
            };
            _customerRepositoryMock.Setup(repo => repo.CreateCustomer(It.IsAny<Customer>())).Returns(customerEntity);

            // Act
            var result = _customerDataService.CreateCustomer(customerDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerDTO.CustomerID, result.CustomerID);
            Assert.AreEqual(customerDTO.UserID, result.UserID);
            CollectionAssert.AreEqual(customerDTO.LinkedVehicles.ToList(), result.LinkedVehicles.ToList());
        }

        [TestMethod]
        public void CreateCustomer_NullCustomerDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _customerDataService.CreateCustomer(null));
        }

        [TestMethod]
        public void GetAllCustomers_ReturnsListOfCustomerDTOs()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { CustomerID = 1, UserID = 1, LinkedVehicles = new List<LinkedVehicles>() },
                new Customer { CustomerID = 2, UserID = 2, LinkedVehicles = new List<LinkedVehicles>() }
            };
            _customerRepositoryMock.Setup(repo => repo.GetAllCustomers()).Returns(customers);

            // Act
            var result = _customerDataService.GetAllCustomers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customers.Count, result.Count());
            CollectionAssert.AreEqual(customers.Select(c => c.CustomerID).ToList(), result.Select(c => c.CustomerID).ToList());
        }
        [TestMethod]
        public void GetCustomerByEmail_ValidEmail_ReturnsCustomerDTO()
        {
            // Arrange
            string email = "test@example.com";
            var customerEntity = new Customer { CustomerID = 1, UserID = 1, LinkedVehicles = new List<LinkedVehicles>() };
            _customerRepositoryMock.Setup(repo => repo.GetCustomerByEmail(email)).Returns(customerEntity);

            // Act
            var result = _customerDataService.GetCustomerByEmail(email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerEntity.CustomerID, result.CustomerID);
            Assert.AreEqual(customerEntity.UserID, result.UserID);
            CollectionAssert.AreEqual(customerEntity.LinkedVehicles.ToList(), result.LinkedVehicles.ToList());
        }

        [TestMethod]
        public void GetCustomerByEmail_NullOrWhitespaceEmail_ThrowsArgumentException()
        {
            // Arrange
            string invalidEmail = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _customerDataService.GetCustomerByEmail(invalidEmail));
        }

        [TestMethod]
        public void GetCustomerByFirstName_ValidFirstName_ReturnsCustomerDTO()
        {
            // Arrange
            string firstName = "John";
            var customerEntity = new Customer { CustomerID = 1, UserID = 1, LinkedVehicles = new List<LinkedVehicles>() };
            _customerRepositoryMock.Setup(repo => repo.GetCustomerByFirstName(firstName)).Returns(customerEntity);

            // Act
            var result = _customerDataService.GetCustomerByFirstName(firstName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerEntity.CustomerID, result.CustomerID);
            Assert.AreEqual(customerEntity.UserID, result.UserID);
            CollectionAssert.AreEqual(customerEntity.LinkedVehicles.ToList(), result.LinkedVehicles.ToList());
        }

        [TestMethod]
        public void GetCustomerByFirstName_NullOrWhitespaceFirstName_ThrowsArgumentException()
        {
            // Arrange
            string invalidFirstName = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _customerDataService.GetCustomerByFirstName(invalidFirstName));
        }
    }
}
