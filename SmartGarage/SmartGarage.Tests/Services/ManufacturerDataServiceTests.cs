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
    public class ManufacturerDataServiceTests
    {
        private Mock<IManufacturerRepository> _mockManufacturerRepository;
        private ManufacturerDataService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockManufacturerRepository = new Mock<IManufacturerRepository>();
            _service = new ManufacturerDataService(_mockManufacturerRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateManufacturer_WithNullManufacturerDTO_ThrowsArgumentNullException()
        {
            _service.CreateManufacturer(null);
        }

        [TestMethod]
        public void GetManufacturerById_WithValidID_ReturnsManufacturerDTO()
        {
            var manufacturer = new Manufacturer {  };
            _mockManufacturerRepository.Setup(repo => repo.GetManufacturerById(It.IsAny<int>())).Returns(manufacturer);

            var result = _service.GetManufacturerById(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetManufacturerById_WithInvalidID_ThrowsArgumentException()
        {
            _service.GetManufacturerById(0);
        }

        [TestMethod]
        public void GetManufacturerByName_WithValidName_ReturnsManufacturerDTO()
        {
            var manufacturer = new Manufacturer {  };
            _mockManufacturerRepository.Setup(repo => repo.GetManufacturerByName(It.IsAny<string>())).Returns(manufacturer);

            var result = _service.GetManufacturerByName("BrandName");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetManufacturerByName_WithInvalidName_ThrowsArgumentException()
        {
            _service.GetManufacturerByName("");
        }

        [TestMethod]
        public void GetAllManufacturers_ReturnsAllManufacturers()
        {
            var manufacturers = new List<Manufacturer> {  };
            _mockManufacturerRepository.Setup(repo => repo.GetAllManufacturers()).Returns(manufacturers);

            var result = _service.GetAllManufacturers();

            Assert.IsNotNull(result);
            Assert.AreEqual(manufacturers.Count, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateManufacturer_WithNullManufacturerDTO_ThrowsArgumentNullException()
        {
            _service.UpdateManufacturer(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateManufacturer_WithNonExistingManufacturer_ThrowsInvalidOperationException()
        {
            _mockManufacturerRepository.Setup(repo => repo.GetManufacturerById(It.IsAny<int>()))
                .Returns((Manufacturer)null);

            _service.UpdateManufacturer(new ManufacturerDTO {  });
        }
    }
}
