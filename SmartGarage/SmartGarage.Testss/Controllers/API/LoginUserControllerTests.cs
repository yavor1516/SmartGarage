using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using SmartGarage.Controllers.API;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Tests.Controllers.API
{
    [TestClass]
    public class LoginUserControllerTests
    {
        private Mock<IAccountService> _mockAccountService;
        private LoginUserController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockAccountService = new Mock<IAccountService>();
            _controller = new LoginUserController(_mockAccountService.Object);
        }

        [TestMethod]
        public void LoginUser_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("TestError", "This is a test error");
            var loginRequest = new UserLoginDTO();

            // Act
            var result = _controller.LoginUser(loginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            var errorResponse = badRequestResult.Value as ErrorResponse;
            var errorMessages = errorResponse.ErrorMessages.ToList();
            Assert.AreEqual(1, errorMessages.Count);
            Assert.AreEqual("This is a test error", errorMessages[0]);
        }
        //[TestMethod]
        //public void LoginUser_ValidRequest_ReturnsOk()                        //MAYBE A TEST WHEN WE GOT VALID TOKEN!!!
        //{
        //    // Arrange                                                           
        //    var loginRequest = new UserLoginDTO { Username = "validUser", Password = "validPass" };  
        //    var loginResult = new LoginResultDTO { /* ... properties set up ... */ };
        //    _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Returns(loginResult);

        //    // Act
        //    var result = _controller.LoginUser(loginRequest);

        //    // Assert
        //    _mockAccountService.Verify(service => service.LoginUser(loginRequest), Times.Once());
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //}
        [TestMethod]
        public void LoginUser_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginRequest = new UserLoginDTO { Username = "invalidUser", Password = "invalidPass" };
            _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Returns(value: null);

            // Act
            var result = _controller.LoginUser(loginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
            var unauthorizedResult = result as UnauthorizedObjectResult;
            var errorResponse = unauthorizedResult.Value as ErrorResponse;
            Assert.AreEqual("Invalid credentials.", errorResponse.ErrorMessages.First());
        }
        [TestMethod]
        public void LoginUser_DuplicateEntity_ReturnsConflict()
        {
            // Arrange
            var loginRequest = new UserLoginDTO { Username = "duplicateUser", Password = "pass" };
            _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Throws(new DuplicateEntityException("Duplicate entity found."));

            // Act
            var result = _controller.LoginUser(loginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
            var conflictResult = result as ConflictObjectResult;
            var errorResponse = conflictResult.Value as ErrorResponse;
            Assert.AreEqual("Duplicate entity found.", errorResponse.ErrorMessages.First());
        }
        [TestMethod]
        public void LoginUser_UnexpectedException_ReturnsInternalServerError()
        {
            // Arrange
            var loginRequest = new UserLoginDTO { Username = "user", Password = "pass" };
            _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Throws(new Exception("Unexpected error occurred."));

            // Act & Assert
            var result = Assert.ThrowsException<Exception>(() => _controller.LoginUser(loginRequest));
            Assert.AreEqual("Unexpected error occurred.", result.Message);
        }
    }
}
