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
    public class CarModelDataServiceTests
    {
        [TestMethod]
        public void CreateCarModel_ValidModel_ReturnsCreatedCarModel()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            var carModelService = new CarModelDataService(mockRepository.Object);
            var validCarModel = new CarModel {Model = "Toyota" };

            // Act
            var createdCarModel = carModelService.CreateCarModel(validCarModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateCarModel_DuplicateModel_ThrowsInvalidOperationException()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            mockRepository.Setup(r => r.GetCarModelByModel(It.IsAny<string>()))
                .Returns(new CarModel { Model="Toyota" });
            var carModelService = new CarModelDataService(mockRepository.Object);
            var duplicateCarModel = new CarModel { Model = "Toyota" };

            // Act
            carModelService.CreateCarModel(duplicateCarModel);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCarModel_NullCarModel_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepository = new Mock<ICarModelRepository>();
            var carModelService = new CarModelDataService(mockRepository.Object);
            CarModel nullCarModel = null;

            // Act
            carModelService.CreateCarModel(nullCarModel);
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
            var carModels = carModelService.GetAllCarModels();
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
