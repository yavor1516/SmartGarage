using Moq;
using SmartGarage.Exceptions;
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
    public class VehicleServiceTests
    {
        private Mock<IVehicleRepository> mockRepo;
        private VehicleDataService service;
        private Vehicle testVehicle;
        private List<Vehicle> vehicleList;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepo = new Mock<IVehicleRepository>();
            service = new VehicleDataService(mockRepo.Object);

            // Initialize a test vehicle object and a list of vehicles if necessary for your tests
            testVehicle = new Vehicle { };
            vehicleList = new List<Vehicle> { };
        }

        [TestMethod]
        public void CreateVehicle_ShouldReturnVehicle_WhenVehicleIsValid()
        {
            // Arrange
            mockRepo.Setup(repo => repo.CreateVehicle(It.IsAny<Vehicle>())).Returns(testVehicle);

            // Act
            var result = service.CreateVehicle(testVehicle);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testVehicle, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateVehicle_ShouldThrowArgumentNullException_WhenVehicleIsNull()
        {
            // Act
            service.CreateVehicle(null);
        }
        [TestMethod]
        public void GetVehiclesByManufacturer_ShouldReturnVehicles_WhenManufacturerExists()
        {
            // Arrange
            string manufacturerName = "TestManufacturer";
            mockRepo.Setup(repo => repo.GetVehiclesByManufacturer(manufacturerName)).Returns(vehicleList.Where(v => v.Manufacturer.BrandName == manufacturerName).ToList());

            // Act
            var result = service.GetVehiclesByManufacturer(manufacturerName);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any()); // Assuming there is at least one vehicle from TestManufacturer
        }

        [TestMethod]
        public void GetVehiclesByManufacturer_ShouldReturnEmpty_WhenManufacturerDoesNotExist()
        {
            // Arrange
            string manufacturerName = "NonExistentManufacturer";
            mockRepo.Setup(repo => repo.GetVehiclesByManufacturer(manufacturerName)).Returns(new List<Vehicle>());

            // Act
            var result = service.GetVehiclesByManufacturer(manufacturerName);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetVehicleByModel_ShouldReturnVehicle_WhenModelExists()
        {
            // Arrange
            string modelName = "TestModel";
            mockRepo.Setup(repo => repo.GetVehicleByModel(modelName)).Returns(vehicleList.FirstOrDefault(v => v.CarModel.Model == modelName));

            // Act
            var result = service.GetVehicleByModel(modelName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(modelName, result.CarModel.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetVehicleByModel_ShouldThrowEntityNotFoundException_WhenModelDoesNotExist()
        {
            // Arrange
            string modelName = "NonExistentModel";
            mockRepo.Setup(repo => repo.GetVehicleByModel(modelName)).Returns((Vehicle)null);

            // Act
            var result = service.GetVehicleByModel(modelName);

            // Assert is handled by the ExpectedException attribute
        }
    }
}
