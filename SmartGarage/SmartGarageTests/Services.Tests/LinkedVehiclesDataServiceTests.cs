using Moq;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Models;
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
    public class LinkedVehiclesDataServiceTests
    {
        private Mock<ILinkedVehiclesRepository> _linkedVehiclesRepositoryMock;
        private Mock<IEmployeeDataService> _employeeDataServiceMock;
        private Mock<IVehicleDataService> _vehicleDataServiceMock;
        private Mock<ICustomerDataService> _customerDataServiceMock;
        private LinkedVehiclesDataService _linkedVehiclesDataService;

        [TestInitialize]
        public void Setup()
        {
            _linkedVehiclesRepositoryMock = new Mock<ILinkedVehiclesRepository>();
            _employeeDataServiceMock = new Mock<IEmployeeDataService>();
            _vehicleDataServiceMock = new Mock<IVehicleDataService>();
            _customerDataServiceMock = new Mock<ICustomerDataService>();
            _linkedVehiclesDataService = new LinkedVehiclesDataService(
                _linkedVehiclesRepositoryMock.Object,
                _employeeDataServiceMock.Object,
                _vehicleDataServiceMock.Object,
                _customerDataServiceMock.Object,
                null // You can mock GarageContext if needed
            );
        }

        // Existing test methods...

        [TestMethod]
        public void UpdateLinkedVehicle_ValidLinkedVehicleDTO_NoExceptionThrown()
        {
            // Arrange
            var linkedVehicleDTO = new LinkedVehiclesDTO { LinkedVehicleID = 1, ModelID = 1, ManufacturerID = 1, EmployeeID = 1, CustomerID = 1, LicensePlate = "ABC123", VIN = "1234567890", YearOfCreation = 2022, InvoiceID = 1, LinkedVehicleServices = new List<LinkedVehicleServiceDTO>() };
            var existingLinkedVehicleEntity = new LinkedVehicles { LinkedVehicleID = 1, ModelID = 1, ManufacturerID = 1, EmployeeID = 1, CustomerID = 1, LicensePlate = "ABC123", VIN = "1234567890", YearOfCreation = 2022, InvoiceID = 1, LinkedVehicleServices = new List<LinkedVehicleService>() };
            _linkedVehiclesRepositoryMock.Setup(repo => repo.GetLinkedVehiclesById(linkedVehicleDTO.LinkedVehicleID)).Returns(existingLinkedVehicleEntity);

            // Act
            _linkedVehiclesDataService.UpdateLinkedVehicle(linkedVehicleDTO);

            // Assert
            _linkedVehiclesRepositoryMock.Verify(repo => repo.UpdateLinkedVehicles(It.IsAny<LinkedVehicles>()), Times.Once);
        }

        [TestMethod]
        public void UpdateLinkedVehicle_NullLinkedVehicleDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _linkedVehiclesDataService.UpdateLinkedVehicle(null));
        }

        [TestMethod]
        public void UpdateLinkedVehicle_InexistentLinkedVehicle_ThrowsEntityNotFoundException()
        {
            // Arrange
            var linkedVehicleDTO = new LinkedVehiclesDTO { LinkedVehicleID = 1, ModelID = 1, ManufacturerID = 1, EmployeeID = 1, CustomerID = 1, LicensePlate = "ABC123", VIN = "1234567890", YearOfCreation = 2022, InvoiceID = 1, LinkedVehicleServices = new List<LinkedVehicleServiceDTO>() };
            _linkedVehiclesRepositoryMock.Setup(repo => repo.GetLinkedVehiclesById(linkedVehicleDTO.LinkedVehicleID)).Returns((LinkedVehicles)null);

            // Act & Assert
            Assert.ThrowsException<EntityNotFoundException>(() => _linkedVehiclesDataService.UpdateLinkedVehicle(linkedVehicleDTO));
        }

        [TestMethod]
        public void CreateLinkedVehicle_ValidLinkedVehicleDTO_ReturnsMappedDTO()
        {
            // Arrange
            var linkedVehiclesDTO = new LinkedVehiclesDTO { /* fill with valid data */ };
            var linkedVehicleEntity = new LinkedVehicles { /* fill with corresponding entity data */ };
            _linkedVehiclesRepositoryMock.Setup(repo => repo.CreateLinkedVehicle(It.IsAny<LinkedVehicles>())).Returns(linkedVehicleEntity);

            // Act
            var createdLinkedVehicleDTO = _linkedVehiclesDataService.CreateLinkedVehicle(linkedVehiclesDTO);

            // Assert
            Assert.IsNotNull(createdLinkedVehicleDTO);
            // Add more assertions as needed
        }

        [TestMethod]
        public void CreateLinkedVehicle_NullLinkedVehicleDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _linkedVehiclesDataService.CreateLinkedVehicle(null));
        }

        [TestMethod]
        public void GetLinkedVehicleById_ValidId_ReturnsMappedDTO()
        {
            // Arrange
            var id = 1;
            var linkedVehicleEntity = new LinkedVehicles { /* fill with corresponding entity data */ };
            _linkedVehiclesRepositoryMock.Setup(repo => repo.GetLinkedVehiclesById(id)).Returns(linkedVehicleEntity);

            // Act
            var linkedVehicleDTO = _linkedVehiclesDataService.GetLinkedVehicleById(id);

            // Assert
            Assert.IsNotNull(linkedVehicleDTO);
            // Add more assertions as needed
        }

        [TestMethod]
        public void GetLinkedVehicleById_NegativeId_ThrowsArgumentException()
        {
            // Arrange
            var negativeId = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _linkedVehiclesDataService.GetLinkedVehicleById(negativeId));
        }
    }
}
