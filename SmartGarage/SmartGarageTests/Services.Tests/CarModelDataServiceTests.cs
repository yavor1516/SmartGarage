using Moq;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class CarModelDataServiceTests
    {
        private Mock<ICarModelRepository> _carModelRepositoryMock;
        private CarModelDataService _carModelDataService;

        [TestInitialize]
        public void Setup()
        {
            _carModelRepositoryMock = new Mock<ICarModelRepository>();
            _carModelDataService = new CarModelDataService(_carModelRepositoryMock.Object);
        }

        [TestMethod]
        public void CreateCarModel_ValidCarModelDTO_CarModelCreated()
        {
            // Arrange
            var carModelDTO = new CarModelDTO { Model = "TestModel", ManufacturerID = 1 };
            _carModelRepositoryMock.Setup(r => r.GetCarModelByModel(carModelDTO.Model)).Returns((CarModel)null);
            _carModelRepositoryMock.Setup(r => r.CreateCarModel(It.IsAny<CarModel>())).Returns(new CarModel());

            // Act
            var result = _carModelDataService.CreateCarModel(carModelDTO);

            // Assert
            Assert.IsNotNull(result);
            _carModelRepositoryMock.Verify(r => r.CreateCarModel(It.IsAny<CarModel>()), Times.Once);
        }

        [TestMethod]
        public void CreateCarModel_ExistingCarModelDTO_ThrowsInvalidOperationException()
        {
            // Arrange
            var carModelDTO = new CarModelDTO { Model = "TestModel", ManufacturerID = 1 };
            _carModelRepositoryMock.Setup(r => r.GetCarModelByModel(carModelDTO.Model)).Returns(new CarModel());

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => _carModelDataService.CreateCarModel(carModelDTO));
            _carModelRepositoryMock.Verify(r => r.CreateCarModel(It.IsAny<CarModel>()), Times.Never);
        }

        [TestMethod]
        public void CreateCarModel_NullCarModelDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _carModelDataService.CreateCarModel(null));
            _carModelRepositoryMock.Verify(r => r.CreateCarModel(It.IsAny<CarModel>()), Times.Never);
        }

        [TestMethod]
        public void GetAllCarModels_ExistingCarModels_ReturnsAllCarModels()
        {
            // Arrange
            var carModels = new List<CarModel>
            {
                new CarModel { CarModelID = 1, Model = "TestModel1", ManufacturerID = 1 },
                new CarModel { CarModelID = 2, Model = "TestModel2", ManufacturerID = 2 }
            };
            _carModelRepositoryMock.Setup(r => r.GetAllCarModels()).Returns(carModels);

            // Act
            var result = _carModelDataService.GetAllCarModels();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(carModels.Count, result.Count);
            Assert.IsTrue(carModels.Select(cm => cm.Model).SequenceEqual(result.Select(cm => cm.Model)));
        }

        [TestMethod]
        public void GetAllCarModels_NoCarModels_ReturnsEmptyList()
        {
            // Arrange
            _carModelRepositoryMock.Setup(r => r.GetAllCarModels()).Returns(new List<CarModel>());

            // Act
            var result = _carModelDataService.GetAllCarModels();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void GetCarModelById_ValidId_ReturnsCarModel()
        {
            // Arrange
            int validId = 1;
            var carModel = new CarModel { CarModelID = validId, Model = "TestModel", ManufacturerID = 1 };
            _carModelRepositoryMock.Setup(r => r.GetCarModelById(validId)).Returns(carModel);

            // Act
            var result = _carModelDataService.GetCarModelById(validId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(validId, result.CarModelID);
            Assert.AreEqual(carModel.Model, result.Model);
        }

        [TestMethod]
        public void GetCarModelById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _carModelDataService.GetCarModelById(invalidId));
        }

        [TestMethod]
        public void GetCarModelByModel_ValidModel_ReturnsCarModel()
        {
            // Arrange
            string validModel = "TestModel";
            var carModel = new CarModel { CarModelID = 1, Model = validModel, ManufacturerID = 1 };
            _carModelRepositoryMock.Setup(r => r.GetCarModelByModel(validModel)).Returns(carModel);

            // Act
            var result = _carModelDataService.GetCarModelByModel(validModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(validModel, result.Model);
        }

        [TestMethod]
        public void GetCarModelByModel_NullOrEmptyModel_ThrowsArgumentException()
        {
            // Arrange
            string nullModel = null;
            string emptyModel = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _carModelDataService.GetCarModelByModel(nullModel));
            Assert.ThrowsException<ArgumentException>(() => _carModelDataService.GetCarModelByModel(emptyModel));
        }
    }
}
