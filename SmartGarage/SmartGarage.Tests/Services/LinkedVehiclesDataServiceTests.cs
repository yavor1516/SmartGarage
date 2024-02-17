using Moq;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Tests.Services
{
    [TestClass]
    public class LinkedVehiclesDataServiceTests
    {
        private Mock<ILinkedVehiclesRepository> _mockLinkedVehiclesRepository;
        private Mock<IEmployeeDataService> _mockEmployeeDataService;
        private Mock<IVehicleDataService> _mockVehicleDataService;
        private Mock<ICustomerDataService> _mockCustomerDataService;
        private LinkedVehiclesDataService _linkedVehiclesService;

        [TestInitialize]
        public void Initialize()
        {
           // _mockLinkedVehiclesRepository = new Mock<ILinkedVehiclesRepository>();
          //  _mockEmployeeDataService = new Mock<IEmployeeDataService>();
           // _mockVehicleDataService = new Mock<IVehicleDataService>();
           // _mockCustomerDataService = new Mock<ICustomerDataService>();

            //_linkedVehiclesService = new LinkedVehiclesDataService(
              //  _mockLinkedVehiclesRepository.Object,
               // _mockEmployeeDataService.Object,
              //  _mockVehicleDataService.Object,
              //  _mockCustomerDataService.Object
            //);
        }

        [TestMethod]
        public void CreateLinkedVehicle_ValidLinkedVehiclesDTO_ReturnsCreatedLinkedVehicleDTO()
        {
            // Arrange
            var linkedVehiclesDTO = new LinkedVehiclesDTO
            {
                // Initialize with valid data
            };

            var expectedLinkedVehicleEntity = new LinkedVehicles
            {
                // Initialize with valid data
            };

            _mockLinkedVehiclesRepository
                .Setup(repo => repo.CreateLinkedVehicle(It.IsAny<LinkedVehicles>()))
                .Returns(expectedLinkedVehicleEntity);

            // Act
            var result = _linkedVehiclesService.CreateLinkedVehicle(linkedVehiclesDTO);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your logic
        }

        [TestMethod]
        public void GetLinkedVehicleByCustomerId_ValidCustomerId_ReturnsLinkedVehicleDTO()
        {
            // Arrange
            var customerId = 1;

            var expectedLinkedVehicleEntity = new LinkedVehicles
            {
                // Initialize with valid data
            };

            _mockLinkedVehiclesRepository
                .Setup(repo => repo.GetLinkedVehiclesByCustomerId(customerId))
                .Returns(expectedLinkedVehicleEntity);

            // Act
            var result = _linkedVehiclesService.GetLinkedVehicleByCustomerId(customerId);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your logic
        }

    }
}
