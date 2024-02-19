using Moq;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class ServiceDataServiceTests
    {
        private Mock<IServiceRepository> _repositoryMock;
        private IServiceDataService _serviceDataService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IServiceRepository>();
            _serviceDataService = new ServiceDataService(_repositoryMock.Object);
        }

        [TestMethod]
        public void GetServiceByID_ValidID_ReturnsServiceDTO()
        {
            // Arrange
            int serviceId = 1;
            var expectedService = new Service
            {
                ServiceID = serviceId,
                EmployeeID = 1,
                Name = "Oil Change",
                Price = 50.00m
            };
            _repositoryMock.Setup(repo => repo.GetServiceByID(serviceId)).Returns(expectedService);

            // Act
            var result = _serviceDataService.GetServiceByID(serviceId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedService.ServiceID, result.ServiceID);
            Assert.AreEqual(expectedService.EmployeeID, result.EmployeeID);
            Assert.AreEqual(expectedService.Name, result.Name);
            Assert.AreEqual(expectedService.Price, result.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetServiceByID_InvalidID_ThrowsArgumentException()
        {
            // Arrange
            int invalidId = 0;

            // Act
            _serviceDataService.GetServiceByID(invalidId);
        }

        [TestMethod]
        public void CreateService_ValidServiceDTO_CreatesAndReturnsService()
        {
            // Arrange
            var serviceDTO = new ServiceDTO
            {
                EmployeeID = 1,
                Name = "Oil Change",
                Price = 50.00m
            };
            var expectedService = new Service
            {
                EmployeeID = serviceDTO.EmployeeID,
                Name = serviceDTO.Name,
                Price = serviceDTO.Price
            };
            _repositoryMock.Setup(repo => repo.GetServiceByName(serviceDTO.Name)).Returns((Service)null);
            _repositoryMock.Setup(repo => repo.CreateService(It.IsAny<Service>())).Returns(expectedService);

            // Act
            var result = _serviceDataService.CreateService(serviceDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedService.EmployeeID, result.EmployeeID);
            Assert.AreEqual(expectedService.Name, result.Name);
            Assert.AreEqual(expectedService.Price, result.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateService_NullServiceDTO_ThrowsArgumentNullException()
        {
            // Act
            _serviceDataService.CreateService(null);
        }

        [TestMethod]
        public void GetServiceByName_ValidName_ReturnsServiceDTO()
        {
            // Arrange
            string serviceName = "Oil Change";
            var expectedService = new Service
            {
                ServiceID = 1,
                EmployeeID = 1,
                Name = serviceName,
                Price = 50.00m
            };
            _repositoryMock.Setup(repo => repo.GetServiceByName(serviceName)).Returns(expectedService);

            // Act
            var result = _serviceDataService.GetServiceByName(serviceName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedService.ServiceID, result.ServiceID);
            Assert.AreEqual(expectedService.EmployeeID, result.EmployeeID);
            Assert.AreEqual(expectedService.Name, result.Name);
            Assert.AreEqual(expectedService.Price, result.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetServiceByName_NullName_ThrowsArgumentException()
        {
            // Act
            _serviceDataService.GetServiceByName(null);
        }

    }
}
