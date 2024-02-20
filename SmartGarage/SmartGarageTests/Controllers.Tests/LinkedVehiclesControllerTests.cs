using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Controllers.Tests
{
    [TestClass]
    public class LinkedVehiclesControllerTests
    {
        private LinkedVehiclesController _controller;
        private Mock<ILinkedVehiclesDataService> _mockLinkedVehiclesService;

        [TestInitialize]
        public void Setup()
        {
            _mockLinkedVehiclesService = new Mock<ILinkedVehiclesDataService>();
            //_controller = new LinkedVehiclesController(_mockLinkedVehiclesService.Object);
        }

   
    }
}
