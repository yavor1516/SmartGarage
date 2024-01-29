using Moq;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Tests.Services
{
    [TestClass]
    public class CustomerDataServiceTests
    {
        private Mock<ICustomerRepository> _mockRepository;
        private CustomerDataService _customerDataService;
        private Customer _validCustomer;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<ICustomerRepository>();
            _customerDataService = new CustomerDataService(_mockRepository.Object);

            _validCustomer = new Customer
            {
                User = new User { Email = "validemail@example.com", FirstName = "Petko", Username = "petkoludia123" },
                CustomerID = 1
                // ... other properties
            };
        }
        [TestMethod]
        public void CreateCustomer_WithValidPoints()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.CreateCustomer(It.IsAny<Customer>())).Returns(_validCustomer);

            // Act
            var result = _customerDataService.CreateCustomer(_validCustomer);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("validemail@example.com", result.User.Email);
        }
        [TestMethod]
        public void CreateCustomer_WithNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _customerDataService.CreateCustomer(null));
        }
        [TestMethod]
        public void CreateCustomer_WithInvalidEmail()
        {
            // Arrange
            var customerWithInvalidEmail = new Customer
            {
                User = new User { Email = "invalidemail" }
                // ... other properties
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _customerDataService.CreateCustomer(customerWithInvalidEmail));
        }
        [TestMethod]
        public void GetCustomerById_WithValidId()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetCustomerById(1)).Returns(_validCustomer);

            // Act
            var result = _customerDataService.GetCustomerById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.CustomerID);
        }
        [TestMethod]
        public void UpdateCustomer_WithNull()
        {
            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => _customerDataService.UpdateCustomer(null));
        }
    }
}
