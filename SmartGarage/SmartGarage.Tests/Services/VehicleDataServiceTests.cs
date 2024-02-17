using Moq;
using SmartGarage.Exceptions;
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
    public class VehicleDataServiceTests
    {
        private Mock<IVehicleRepository> _mockVehicleRepository;
        private Mock<GarageContext> _mockGarageContext;
        private VehicleDataService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _mockGarageContext = new Mock<GarageContext>();
            _service = new VehicleDataService(_mockVehicleRepository.Object, _mockGarageContext.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateVehicle_WithNullVehicleDTO_ThrowsArgumentNullException()
        {
            _service.CreateVehicle(null);
        }

        [TestMethod]
        public void GetVehicleByID_ExistingID_ReturnsVehicleDTO()
        {
            var vehicle = new Vehicle { /* initialize properties */ };
            _mockVehicleRepository.Setup(repo => repo.GetVehicleById(It.IsAny<int>())).Returns(vehicle);

            var result = _service.GetVehicleByID(1);

            Assert.IsNotNull(result);
            // Additional assertions
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void GetVehicleByID_NonExistingID_ThrowsEntityNotFoundException()
        {
            _mockVehicleRepository.Setup(repo => repo.GetVehicleById(It.IsAny<int>())).Returns((Vehicle)null);

            _service.GetVehicleByID(999);
        }

        [TestMethod]
        public void GetVehiclesByManufacturerName_ValidName_ReturnsVehicles()
        {
            var vehicles = new List<Vehicle> { /* initialize with test data */ };
            _mockVehicleRepository.Setup(repo => repo.GetVehiclesByManufacturerName(It.IsAny<string>())).Returns(vehicles);

            var result = _service.GetVehiclesByManufacturerName("ManufacturerName");

            Assert.IsNotNull(result);
            Assert.AreEqual(vehicles.Count, result.Count);
        }

        [TestMethod]
        public void UpdateVehicle_ValidVehicleDTO_UpdatesVehicle()
        {
            var vehicleDTO = new VehicleDTO { /* initialize properties */ };
            var vehicle = new Vehicle { /* initialize properties */ };
            _mockVehicleRepository.Setup(repo => repo.GetVehicleById(It.IsAny<int>())).Returns(vehicle);

            _service.UpdateVehicle(vehicleDTO);

            // Assert that update method was called on repository
            _mockVehicleRepository.Verify(repo => repo.UpdateVehicle(It.IsAny<Vehicle>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateVehicle_NullVehicleDTO_ThrowsArgumentNullException()
        {
            _service.UpdateVehicle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void UpdateVehicle_NonExistingVehicle_ThrowsEntityNotFoundException()
        {
            _mockVehicleRepository.Setup(repo => repo.GetVehicleById(It.IsAny<int>())).Returns((Vehicle)null);

            var vehicleDTO = new VehicleDTO { /* initialize properties */ };
            _service.UpdateVehicle(vehicleDTO);
        }
    }
}
