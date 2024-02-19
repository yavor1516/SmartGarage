using Moq;
using SmartGarage.Models;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class LinkedVehicleServiceServiceTests
    {
        private Mock<ILinkedVehicleServiceRepository> _repositoryMock;
        private LinkedVehicleServiceService _linkedVehicleServiceService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<ILinkedVehicleServiceRepository>();
            _linkedVehicleServiceService = new LinkedVehicleServiceService(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task GetLinkedVehicleServiceAsync_ValidIds_ReturnsLinkedVehicleService()
        {
            // Arrange
            int linkedVehicleId = 1;
            int serviceId = 1;
            var expectedLinkedVehicleService = new LinkedVehicleService { /* fill with test data */ };
            _repositoryMock.Setup(repo => repo.GetByIdAsync(linkedVehicleId, serviceId)).ReturnsAsync(expectedLinkedVehicleService);

            // Act
            var result = await _linkedVehicleServiceService.GetLinkedVehicleServiceAsync(linkedVehicleId, serviceId);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions as needed
        }

        [TestMethod]
        public async Task GetAllLinkedVehicleServicesAsync_ReturnsListOfLinkedVehicleServices()
        {
            // Arrange
            var expectedLinkedVehicleServices = new List<LinkedVehicleService> { /* fill with test data */ };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedLinkedVehicleServices);

            // Act
            var result = await _linkedVehicleServiceService.GetAllLinkedVehicleServicesAsync();

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions as needed
        }

    }
}
