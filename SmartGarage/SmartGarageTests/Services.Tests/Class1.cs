using Moq;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;
using SmartGarage.Services;
using SmartGarage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class VehicleDataServiceTests
    {
        private Mock<IVehicleRepository> _repositoryMock;
        private Mock<GarageContext> _contextMock;
        private IVehicleDataService _vehicleDataService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IVehicleRepository>();
            _contextMock = new Mock<GarageContext>();
            _vehicleDataService = new VehicleDataService(_repositoryMock.Object, _contextMock.Object);
        }

        // Existing test methods...

        [TestMethod]
        public void CreateVehicle_ValidVehicleDTO_CallsRepositoryCreateVehicle()
        {
            // Arrange
            var vehicleDTO = new VehicleDTO { /* fill with test data */ };
            var vehicleEntity = new Vehicle { /* fill with expected data */ };
            _repositoryMock.Setup(repo => repo.CreateVehicle(It.IsAny<Vehicle>())).Returns(vehicleEntity);

            // Act
            var result = _vehicleDataService.CreateVehicle(vehicleDTO);

            // Assert
            _repositoryMock.Verify(repo => repo.CreateVehicle(It.IsAny<Vehicle>()), Times.Once);
            Assert.IsNotNull(result);
            // Add more specific assertions if needed
        }

        [TestMethod]
        public void GetVehicleByID_ExistingID_ReturnsVehicleDTO()
        {
            // Arrange
            int vehicleId = 1;
            var vehicleEntity = new Vehicle { /* fill with test data */ };
            _repositoryMock.Setup(repo => repo.GetVehicleById(vehicleId)).Returns(vehicleEntity);

            // Act
            var result = _vehicleDataService.GetVehicleByID(vehicleId);

            // Assert
            Assert.IsNotNull(result);
            // Add more specific assertions if needed
        }

        [TestMethod]
        public void GetVehicleByID_NonExistingID_ThrowsEntityNotFoundException()
        {
            // Arrange
            int vehicleId = 999;
            _repositoryMock.Setup(repo => repo.GetVehicleById(vehicleId)).Returns((Vehicle)null);

            // Act & Assert
            Assert.ThrowsException<EntityNotFoundException>(() => _vehicleDataService.GetVehicleByID(vehicleId));
        }

        [TestMethod]
        public void GetAllVehiclesByEmployeeID_ValidEmployeeID_ReturnsListOfVehicleDTO()
        {
            // Arrange
            int employeeId = 1;
            var vehicles = new List<Vehicle> { /* fill with test data */ };
            _repositoryMock.Setup(repo => repo.GetAllVehiclesByEmployeeID(employeeId)).Returns(vehicles);

            // Act
            var result = _vehicleDataService.GetAllVehiclesByEmployeeID(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(vehicles.Count, result.Count);
            // Add more specific assertions if needed
        }

        [TestMethod]
        public void GetAllVehiclesByEmployeeID_InvalidEmployeeID_ThrowsArgumentException()
        {
            // Arrange
            int employeeId = 0;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _vehicleDataService.GetAllVehiclesByEmployeeID(employeeId));
        }

        [TestMethod]
        public void GetAllVehiclesByManufacturerName_ValidManufacturer_ReturnsListOfVehicleDTO()
        {
            // Arrange
            string manufacturer = "Toyota";
            var vehicles = new List<Vehicle> { /* fill with test data */ };
            _repositoryMock.Setup(repo => repo.GetVehiclesByManufacturerName(manufacturer)).Returns(vehicles);

            // Act
            var result = _vehicleDataService.GetVehiclesByManufacturerName(manufacturer);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(vehicles.Count, result.Count);
            // Add more specific assertions if needed
        }
    }
}
