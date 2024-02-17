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
    public class ServiceDataServiceTests
    {
        [TestMethod]
        public void GetServiceById_ValidId_ReturnsService()
        {
            // Arrange
            var mockRepository = new Mock<IServiceRepository>();
            mockRepository.Setup(r => r.GetServiceByID(It.IsAny<int>()))
                .Returns(new Service { /* Initialize with valid properties */ });
            var serviceService = new ServiceDataService(mockRepository.Object);
            var validId = 1; // Valid service ID

            // Act
            var service = serviceService.GetServiceByID(validId);

            // Assert
            // Ensure the returned service is not null and has the expected properties
            // Add your assertions here
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetServiceById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<IServiceRepository>();
            var serviceService = new ServiceDataService(mockRepository.Object);
            var invalidId = 0; // Invalid ID

            // Act
            serviceService.GetServiceByID(invalidId);

            // Assert
            // Exception is expected
        }

        [TestMethod]
        public void GetServiceByName_ValidName_ReturnsService()
        {
            // Arrange
            // Mock the repository to return a service with a valid name
            var mockRepository = new Mock<IServiceRepository>();
            mockRepository.Setup(r => r.GetServiceByName(It.IsAny<string>()))
                .Returns(new Service { /* Initialize with valid properties */ });
            var serviceService = new ServiceDataService(mockRepository.Object);
            var validName = "ServiceName"; // Valid service name

            // Act
            var service = serviceService.GetServiceByName(validName);

            // Assert
            // Ensure the returned service is not null and has the expected properties
            // Add your assertions here
        }

         [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetServiceByName_NullName_ThrowsArgumentException()
    {
        // Arrange
        var mockRepository = new Mock<IServiceRepository>();
        var serviceService = new ServiceDataService(mockRepository.Object);
        string nullName = null; // Null service name

        // Act
        serviceService.GetServiceByName(nullName);

        // Assert
        // Exception is expected
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetServiceByName_EmptyName_ThrowsArgumentException()
    {
        // Arrange
        var mockRepository = new Mock<IServiceRepository>();
        var serviceService = new ServiceDataService(mockRepository.Object);
        string emptyName = ""; // Empty service name

        // Act
        serviceService.GetServiceByName(emptyName);

        // Assert
        // Exception is expected
    }

    [TestMethod]
    public void GetServiceByPrice_ValidPrice_ReturnsService()
    {
        // Arrange
        // Mock the repository to return a service with a valid price
        var mockRepository = new Mock<IServiceRepository>();
        mockRepository.Setup(r => r.GetServiceByPrice(It.IsAny<decimal>()))
            .Returns(new Service { /* Initialize with valid properties */ });
        var serviceService = new ServiceDataService(mockRepository.Object);
        decimal validPrice = 100.00m; // Valid service price

        // Act
        var service = serviceService.GetServiceByPrice(validPrice);

        // Assert
        // Ensure the returned service is not null and has the expected properties
        // Add your assertions here
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetServiceByPrice_NegativePrice_ThrowsArgumentException()
    {
        // Arrange
        var mockRepository = new Mock<IServiceRepository>();
        var serviceService = new ServiceDataService(mockRepository.Object);
        decimal negativePrice = -50;

        // Act
        serviceService.GetServiceByPrice(negativePrice);

        // Assert
        // Exception is expected
    }

    }
}
