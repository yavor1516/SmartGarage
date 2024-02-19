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
        public void CreateCustomer_NullCustomerDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _customerDataService.CreateCustomer(null));
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
        public void GetCustomerByFirstName_NullOrWhitespaceFirstName_ThrowsArgumentException()
        {
            // Arrange
            string invalidFirstName = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _customerDataService.GetCustomerByFirstName(invalidFirstName));
        }
    }
}
