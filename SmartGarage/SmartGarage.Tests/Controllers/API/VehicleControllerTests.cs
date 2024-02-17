using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers.API;
using SmartGarage.Models.DTO;
using SmartGarage.Responses;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Tests.Controllers.API
{
    [TestClass]
    public class VehicleControllerTests
    {
        private Mock<IVehicleDataService> _mockVehicleDataService;
        private VehicleController _controller;

        [TestInitialize]
        public void SetUp()
        {
            _mockVehicleDataService = new Mock<IVehicleDataService>();
            _controller = new VehicleController(_mockVehicleDataService.Object);
        }

        //[TestMethod]
        //public void GetAllVehicles_ReturnsOkObjectResult()
        //{
        //    // Arrange
        //    var fakeVehicle = new Vehicle
        //    {
        //        Manufacturer = new Manufacturer { BrandName = "TestBrand" },
        //        CarModel = new CarModel { Model = "TestModel" }
        //    };
        //    _mockVehicleDataService.Setup(service => service.GetVehicleByID(1)).Returns(fakeVehicle);

        //    // Act
        //    var result = _controller.GetAllVehicles();

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.IsInstanceOfType(okResult.Value, typeof(VehicleResponse));
        //    var vehicleResponse = okResult.Value as VehicleResponse;
        //    Assert.AreEqual("TestBrand", vehicleResponse.VehicleBrand);
        //    Assert.AreEqual("TestModel", vehicleResponse.VehicleModel);
        //}
       

        //[TestMethod]
        //public void CreateVehicle_WithExistingVehicle_ReturnsBadRequest()     //TODO when we have CarModelDTO and ManufacturerDTO
        //{
        //    // Arrange
        //    var vehicleDTO = new VehicleDTO
        //    {
        //        Manufacturer = new ManufacturerDTO { BrandName = "TestBrand" },
        //        CarModel = new CarModelDTO { Model = "TestModel" }
        //    };
        //    _mockVehicleDataService.Setup(service => service.GetVehiclesByManufacturer(vehicleDTO.Manufacturer.BrandName)).Returns(new List<Vehicle>());
        //    _mockVehicleDataService.Setup(service => service.GetVehicleByModel(vehicleDTO.CarModel.Model)).Returns(new Vehicle());

        //    // Act
        //    var result = _controller.CreateVehicle(vehicleDTO);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //}

        //[TestMethod]
        //public void CreateVehicle_WithNewVehicle_ReturnsOkResult()
        //{
        //    // Arrange
        //    var vehicleDTO = new VehicleDTO
        //    {
        //        Manufacturer = new ManufacturerDTO { BrandName = "TestBrand" },
        //        CarModel = new CarModelDTO { Model = "TestModel" }
        //    };
        //    _mockVehicleDataService.Setup(service => service.GetVehiclesByManufacturer(vehicleDTO.Manufacturer.BrandName)).Returns(new List<Vehicle>());
        //    _mockVehicleDataService.Setup(service => service.GetVehicleByModel(vehicleDTO.CarModel.Model)).Returns((Vehicle)null);

        //    // Act
        //    var result = _controller.CreateVehicle(vehicleDTO);

        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkResult));
        //}
    }
}
