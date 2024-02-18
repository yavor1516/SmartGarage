using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers.API;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Controllers.Tests
{
    [TestClass]
    public class AdminPanelControllerTests
    {
        private AdminPanelController _controller;
        private Mock<IAdminPanelDataService> _mockAdminPanelService;

        [TestInitialize]
        public void Setup()
        {
            _mockAdminPanelService = new Mock<IAdminPanelDataService>();
            _controller = new AdminPanelController(_mockAdminPanelService.Object);
            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Role, "True")
            }, "mock"));

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = userClaims }
            };
        }

        [TestMethod]
        public void BlockUser_ValidUser_ReturnsOkResult()
        {
            // Arrange
            string username = "testUser";

            // Act
            var result = _controller.BlockUser(username);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void UnBlockUser_ValidUser_ReturnsOkResult()
        {
            // Arrange
            string username = "testUser";

            // Act
            var result = _controller.UnBlockUser(username);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
