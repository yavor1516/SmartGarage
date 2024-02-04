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
    public class ManufacturerDataServiceTests
    {
        [TestMethod]
        public void CreateManufacturer_ValidManufacturer_ReturnsCreatedManufacturer()
        {
            // Arrange
            var mockRepository = new Mock<IManufacturerRepository>();
            var manufacturerService = new ManufacturerDataService(mockRepository.Object);

            var validManufacturer = new Manufacturer{};

            mockRepository.Setup(r => r.CreateManufacturer(validManufacturer))
                .Returns(validManufacturer);

            // Act
            var createdManufacturer = manufacturerService.CreateManufacturer(validManufacturer);

            // Assert
            Assert.IsNotNull(createdManufacturer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateManufacturer_NullManufacturer_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepository = new Mock<IManufacturerRepository>();
            var manufacturerService = new ManufacturerDataService(mockRepository.Object);

            // Act and Assert
            manufacturerService.CreateManufacturer(null);
        }

        [TestMethod]
        public void GetManufacturerById_ValidId_ReturnsManufacturer()
        {
            // Arrange
            var mockRepository = new Mock<IManufacturerRepository>();
            var manufacturerService = new ManufacturerDataService(mockRepository.Object);

            int validManufacturerId = 1;
            var validManufacturer = new Manufacturer
            {
                ManufacturerID = validManufacturerId,
            };

            mockRepository.Setup(r => r.GetManufacturerById(validManufacturerId))
                .Returns(validManufacturer);

            // Act
            var retrievedManufacturer = manufacturerService.GetManufacturerById(validManufacturerId);

            // Assert
            Assert.IsNotNull(retrievedManufacturer);
            Assert.AreEqual(validManufacturerId, retrievedManufacturer.ManufacturerID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetManufacturerById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<IManufacturerRepository>();
            var manufacturerService = new ManufacturerDataService(mockRepository.Object);

            int invalidManufacturerId = -1;

            // Act and Assert
            manufacturerService.GetManufacturerById(invalidManufacturerId);
        }
    }
}
