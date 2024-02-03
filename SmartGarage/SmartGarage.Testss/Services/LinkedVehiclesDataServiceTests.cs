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
    public class LinkedVehiclesDataServiceTests
    {
        private Mock<ILinkedVehiclesRepository> mockRepository;
        private LinkedVehiclesDataService service;
        private LinkedVehicles dummyLinkedVehicle;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new Mock<ILinkedVehiclesRepository>();
            service = new LinkedVehiclesDataService(mockRepository.Object);
            dummyLinkedVehicle = new LinkedVehicles {};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateLinkedVehicle_NullLinkedVehicle_ThrowsArgumentNullException()
        {
            // Arrange 

            // Act
            service.CreateLinkedVehicle(null);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void CreateLinkedVehicle_ValidLinkedVehicle_CallsRepositoryCreateMethod()
        {
            // Arrange 

            // Act
            service.CreateLinkedVehicle(dummyLinkedVehicle);

            // Assert
            mockRepository.Verify(r => r.CreateLinkedVehicle(It.IsAny<LinkedVehicles>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Customer ID must be greater than zero.")]
        public void GetLinkedVehicleByCustomerId_InvalidCustomerId_ThrowsArgumentException()
        {
            // Arrange
            int invalidCustomerId = 0;

            // Act
            service.GetLinkedVehicleByCustomerId(invalidCustomerId);

            // Assert 
        }

        [TestMethod]
        public void GetLinkedVehicleByCustomerId_ValidCustomerId_CallsRepositoryGetMethod()
        {
            // Arrange
            int validCustomerId = 1;

            // Act
            service.GetLinkedVehicleByCustomerId(validCustomerId);

            // Assert
            mockRepository.Verify(r => r.GetLinkedVehiclesByCustomerId(validCustomerId), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Customer name cannot be null or whitespace.")]
        public void GetLinkedVehicleByCustomerName_NullOrWhitespaceName_ThrowsArgumentException()
        {
            // Arrange
            string invalidCustomerName = " ";

            // Act
            service.GetLinkedVehicleByCustomerName(invalidCustomerName);

            // Assert 
        }

        [TestMethod]
        public void GetLinkedVehicleByCustomerName_ValidName_CallsRepositoryGetMethod()
        {
            // Arrange
            string validCustomerName = "John Doe";

            // Act
            service.GetLinkedVehicleByCustomerName(validCustomerName);

            // Assert
            mockRepository.Verify(r => r.GetLinkedVehiclesByCustomerName(validCustomerName), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Employee ID must be greater than zero.")]
        public void GetLinkedVehicleByEmployeeId_InvalidEmployeeId_ThrowsArgumentException()
        {
            // Arrange
            int invalidEmployeeId = -1;

            // Act
            service.GetLinkedVehicleByEmployeeId(invalidEmployeeId);

            // Assert 
        }

        [TestMethod]
        public void GetLinkedVehicleByEmployeeId_ValidEmployeeId_CallsRepositoryGetMethod()
        {
            // Arrange
            int validEmployeeId = 1;

            // Act
            service.GetLinkedVehicleByEmployeeId(validEmployeeId);

            // Assert
            mockRepository.Verify(r => r.GetLinkedVehiclesByEmployeeId(validEmployeeId), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "License plate cannot be null or whitespace.")]
        public void GetLinkedVehicleByLicensePlate_NullOrWhitespaceLicensePlate_ThrowsArgumentException()
        {
            // Arrange
            string invalidLicensePlate = "";

            // Act
            service.GetLinkedVehicleByLicensePlate(invalidLicensePlate);

            // Assert 
        }

        [TestMethod]
        public void GetLinkedVehicleByLicensePlate_ValidLicensePlate_CallsRepositoryGetMethod()
        {
            // Arrange
            string validLicensePlate = "XYZ 1234";

            // Act
            service.GetLinkedVehicleByLicensePlate(validLicensePlate);

            // Assert
            mockRepository.Verify(r => r.GetLinkedVehiclesByLicensePlate(validLicensePlate), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Model name cannot be null or whitespace.")]
        public void GetLinkedVehicleByModelName_NullOrWhitespaceModelName_ThrowsArgumentException()
        {
            // Arrange
            string invalidModelName = "   ";

            // Act
            service.GetLinkedVehicleByModelName(invalidModelName);

            // Assert 
        }

        [TestMethod]
        public void GetLinkedVehicleByModelName_ValidModelName_CallsRepositoryGetMethod()
        {
            // Arrange
            string validModelName = "Civic";

            // Act
            service.GetLinkedVehicleByModelName(validModelName);

            // Assert
            mockRepository.Verify(r => r.GetLinkedVehiclesByModelName(validModelName), Times.Once);
        }

        [TestMethod]
        public void UpdateLinkedVehicle_NullLinkedVehicle_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.UpdateLinkedVehicle(null));
        }

        [TestMethod]
        public void UpdateLinkedVehicle_ValidLinkedVehicle_CallsRepositoryUpdateMethod()
        {
            // Arrange

            // Act
            service.UpdateLinkedVehicle(dummyLinkedVehicle);

            // Assert
            mockRepository.Verify(r => r.UpdateLinkedVehicles(dummyLinkedVehicle), Times.Once);
        }
    }
}
