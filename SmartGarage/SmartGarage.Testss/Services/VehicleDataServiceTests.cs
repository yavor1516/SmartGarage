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
        [TestMethod]
        public void CreateVehicle_ValidVehicleDTO_ReturnsCreatedVehicleDTO()
        {
            // Arrange
            var mockRepository = new Mock<IVehicleRepository>();
            var vehicleService = new VehicleDataService(mockRepository.Object);
            var vehicleDTO = new VehicleDTO
            {
            };

            var expectedVehicleEntity = new Vehicle
            {
            };

            mockRepository.Setup(repo => repo.CreateVehicle(It.IsAny<Vehicle>())).Returns(expectedVehicleEntity);

            // Act
            var result = vehicleService.CreateVehicle(vehicleDTO);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllVehiclesByEmployeeID_ValidEmployeeId_ReturnsListOfVehicleDTOs()
        {
            // Arrange
            var mockRepository = new Mock<IVehicleRepository>();
            var vehicleService = new VehicleDataService(mockRepository.Object);
            var employeeId = 1;

            var expectedVehicleEntities = new List<Vehicle>
            {
            };

            mockRepository.Setup(repo => repo.GetAllVehiclesByEmployeeID(employeeId)).Returns(expectedVehicleEntities);

            // Act
            var result = vehicleService.GetAllVehiclesByEmployeeID(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

    }
}
