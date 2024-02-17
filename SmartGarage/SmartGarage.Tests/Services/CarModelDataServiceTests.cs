using Moq;
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
    public class CarModelDataServiceTests
    {
        private Mock<ICarModelRepository> _mockCarModelRepository;
        private CarModelDataService _carModelService;

        [TestInitialize]
        public void Initialize()
        {
            _mockCarModelRepository = new Mock<ICarModelRepository>();
            _carModelService = new CarModelDataService(_mockCarModelRepository.Object);
        }

        [TestMethod]
        public void CreateCarModel_ValidCarModelDTO_ReturnsCreatedCarModelDTO()
        {
            // Arrange
            var carModelDTO = new CarModelDTO
            {
                // Initialize with valid data
            };

            var expectedCarModelEntity = new CarModel
            {
                // Initialize with valid data
            };

            _mockCarModelRepository
                .Setup(repo => repo.GetCarModelByModel(It.IsAny<string>()))
                .Returns((string model) => null);

            _mockCarModelRepository
                .Setup(repo => repo.CreateCarModel(It.IsAny<CarModel>()))
                .Returns(expectedCarModelEntity);

            // Act
            var result = _carModelService.CreateCarModel(carModelDTO);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your logic
        }

        [TestMethod]
        public void CreateCarModel_CarModelAlreadyExists_ThrowsInvalidOperationException()
        {
            // Arrange
            var carModelDTO = new CarModelDTO
            {
                // Initialize with valid data
            };

            _mockCarModelRepository
                .Setup(repo => repo.GetCarModelByModel(It.IsAny<string>()))
                .Returns(new CarModel());

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => _carModelService.CreateCarModel(carModelDTO));
        }

        [TestMethod]
        public void CreateCarModel_NullCarModelDTO_ThrowsArgumentNullException()
        {
            // Arrange
            CarModelDTO carModelDTO = null;

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => _carModelService.CreateCarModel(carModelDTO));
        }

        // Add more test methods for other service methods following a similar pattern
    }
}
