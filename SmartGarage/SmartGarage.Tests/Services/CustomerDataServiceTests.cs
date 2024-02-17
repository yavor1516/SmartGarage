using Moq;
using SmartGarage.Models.DTO;
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
        private Mock<ICustomerRepository> _mockCustomerRepository;
        private CustomerDataService _customerService;

        [TestInitialize]
        public void Initialize()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _customerService = new CustomerDataService(_mockCustomerRepository.Object);
        }

        [TestMethod]
        public void CreateCustomer_ValidCustomerDTO_ReturnsCreatedCustomerDTO()
        {
            // Arrange
            var customerDTO = new CustomerDTO
            {
            };

            var expectedCustomerEntity = new Customer
            {
            };

            _mockCustomerRepository
                .Setup(repo => repo.CreateCustomer(It.IsAny<Customer>()))
                .Returns(expectedCustomerEntity);

            // Act
            var result = _customerService.CreateCustomer(customerDTO);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateCustomer_NullCustomerDTO_ThrowsArgumentNullException()
        {
            // Arrange
            CustomerDTO customerDTO = null;

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => _customerService.CreateCustomer(customerDTO));
        }
    }
}
