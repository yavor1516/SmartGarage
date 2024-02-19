using Moq;
using SmartGarage.Models.DTO;
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
    public class ManufacturerDataServiceTests
    {
        private Mock<IManufacturerRepository> _repositoryMock;
        private IManufacturerDataService _manufacturerDataService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IManufacturerRepository>();
            _manufacturerDataService = new ManufacturerDataService(_repositoryMock.Object);
        }

        [TestMethod]
        public void CreateManufacturer_ValidManufacturerDTO_ReturnsCreatedManufacturerDTO()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO
            {
                ManufacturerID = 1,
                BrandName = "Toyota"
            };
            var expectedManufacturer = new Manufacturer
            {
                ManufacturerID = 1,
                BrandName = "Toyota"
            };
            _repositoryMock.Setup(repo => repo.CreateManufacturer(It.IsAny<Manufacturer>())).Returns(expectedManufacturer);

            // Act
            var result = _manufacturerDataService.CreateManufacturer(manufacturerDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(manufacturerDTO.ManufacturerID, result.ManufacturerID);
            Assert.AreEqual(manufacturerDTO.BrandName, result.BrandName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateManufacturer_NullManufacturerDTO_ThrowsArgumentNullException()
        {
            // Act
            _manufacturerDataService.CreateManufacturer(null);
        }

        [TestMethod]
        public void GetManufacturerById_ValidId_ReturnsManufacturerDTO()
        {
            // Arrange
            int manufacturerId = 1;
            var expectedManufacturer = new Manufacturer
            {
                ManufacturerID = manufacturerId,
                BrandName = "Toyota"
            };
            _repositoryMock.Setup(repo => repo.GetManufacturerById(manufacturerId)).Returns(expectedManufacturer);

            // Act
            var result = _manufacturerDataService.GetManufacturerById(manufacturerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedManufacturer.ManufacturerID, result.ManufacturerID);
            Assert.AreEqual(expectedManufacturer.BrandName, result.BrandName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetManufacturerById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidId = 0;

            // Act
            _manufacturerDataService.GetManufacturerById(invalidId);
        }

        [TestMethod]
        public void GetAllManufacturers_ReturnsListOfManufacturerDTOs()
        {
            // Arrange
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { ManufacturerID = 1, BrandName = "Toyota" },
                new Manufacturer { ManufacturerID = 2, BrandName = "Honda" }
            };
            _repositoryMock.Setup(repo => repo.GetAllManufacturers()).Returns(manufacturers);

            // Act
            var result = _manufacturerDataService.GetAllManufacturers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(manufacturers.Count, result.Count);
            for (int i = 0; i < manufacturers.Count; i++)
            {
                Assert.AreEqual(manufacturers[i].ManufacturerID, result.ElementAt(i).ManufacturerID);
                Assert.AreEqual(manufacturers[i].BrandName, result.ElementAt(i).BrandName);
            }
        }

        [TestMethod]
        public void UpdateManufacturer_ValidManufacturerDTO_CallsRepositoryUpdateMethod()
        {
            // Arrange
            var manufacturerDTO = new ManufacturerDTO { ManufacturerID = 1, BrandName = "Toyota" };
            var expectedManufacturer = new Manufacturer { ManufacturerID = 1, BrandName = "Toyota" };
            _repositoryMock.Setup(repo => repo.GetManufacturerById(manufacturerDTO.ManufacturerID)).Returns(expectedManufacturer);

            // Act
            _manufacturerDataService.UpdateManufacturer(manufacturerDTO);

            // Assert
            _repositoryMock.Verify(repo => repo.UpdateManufacturer(expectedManufacturer), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateManufacturer_NullManufacturerDTO_ThrowsArgumentNullException()
        {
            // Act
            _manufacturerDataService.UpdateManufacturer(null);
        }
    }
}
