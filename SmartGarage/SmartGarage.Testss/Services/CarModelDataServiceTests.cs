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
        [TestMethod]
        public void CreateCarModel_ValidModel_ReturnsCreatedCarModel()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            var carModelService = new CarModelDataService(mockRepository.Object);
            var validCarModelDTO = new CarModelDTO { Model = "Toyota" };

            // Act
            var createdCarModelDTO = carModelService.CreateCarModel(validCarModelDTO);

            // Assert
            Assert.IsNotNull(createdCarModelDTO);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateCarModel_DuplicateModel_ThrowsInvalidOperationException()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            mockRepository.Setup(r => r.GetCarModelByModel(It.IsAny<string>()))
                .Returns(new CarModel { Model = "Toyota" });
            var carModelService = new CarModelDataService(mockRepository.Object);
            var duplicateCarModelDTO = new CarModelDTO { Model = "Toyota" };

            // Act
            carModelService.CreateCarModel(duplicateCarModelDTO);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCarModel_NullCarModel_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            var carModelService = new CarModelDataService(mockRepository.Object);
            CarModelDTO nullCarModelDTO = null;

            // Act
            carModelService.CreateCarModel(nullCarModelDTO);
        }

        [TestMethod]
        public void GetAllCarModels_ReturnsListOfCarModels()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            mockRepository.Setup(r => r.GetAllCarModels())
                .Returns(new List<CarModel> {});
            var carModelService = new CarModelDataService(mockRepository.Object);

            // Act
            var carModelsDTO = carModelService.GetAllCarModels();

            // Assert
            Assert.IsNotNull(carModelsDTO);
            Assert.IsTrue(carModelsDTO.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCarModelById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            mockRepository.Setup(r => r.GetCarModelById(It.IsAny<int>()))
                .Returns((CarModel)null);
            var carModelService = new CarModelDataService(mockRepository.Object);
            var invalidId = -1;

            // Act
            carModelService.GetCarModelById(invalidId);
        }
    }
}
