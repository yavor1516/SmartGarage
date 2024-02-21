using ForumSystem.Exceptions;
using ForumSystem.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers.API;
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
    public class AuthControllerTests
    {
        private AuthController _controller;
        private Mock<IAccountService> _mockAccountService;

        [TestInitialize]
        public void Setup()
        {
            _mockAccountService = new Mock<IAccountService>();
          //  _controller = new AuthController(_mockAccountService.Object);
        }

       /* [TestMethod]
        public void RegisterUser_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var registerRequest = new RegisterUserDTO {  };

            // Act
            var result = _controller.RegisterUser(registerRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void RegisterUser_InvalidModelState_ReturnsBadRequestResultWithErrorResponse()
        {
            // Arrange
            _controller.ModelState.AddModelError("Key", "Error message");

            // Act
            var result = _controller.RegisterUser(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.IsInstanceOfType(badRequestResult.Value, typeof(ErrorResponse));
        }

        [TestMethod]
        public void RegisterUser_DuplicateEntityException_ReturnsConflictResultWithErrorResponse()
        {
            // Arrange
            _mockAccountService.Setup(service => service.RegisterUser(It.IsAny<RegisterUserDTO>()))
                .Throws(new DuplicateEntityException("Duplicate entity message"));

            // Act
            var result = _controller.RegisterUser(new RegisterUserDTO());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
            var conflictResult = (ConflictObjectResult)result;
            Assert.IsInstanceOfType(conflictResult.Value, typeof(ErrorResponse));
        }

        [TestMethod]
        public void LoginUser_ValidRequest_ReturnsOkResultWithAuthenticatedUserResponse()
        {
            // Arrange
            var loginRequest = new LoginUserDTO {  };
            var mockUser = new User {  };
            _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Returns(mockUser);
            _mockAccountService.Setup(service => service.GenerateToken(mockUser)).Returns("mockAccessToken");

            // Act
            var result = _controller.LoginUser(loginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOfType(okResult.Value, typeof(AuthenticatedUserResponse));
        }

        [TestMethod]
        public void LoginUser_InvalidModelState_ReturnsBadRequestResultWithErrorResponse()
        {
            // Arrange
            _controller.ModelState.AddModelError("Key", "Error message");

            // Act
            var result = _controller.LoginUser(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.IsInstanceOfType(badRequestResult.Value, typeof(ErrorResponse));
        }

        [TestMethod]
        public void LoginUser_InvalidCredentials_ReturnsUnauthorizedResultWithErrorResponse()
        {
            // Arrange
            var loginRequest = new LoginUserDTO {  };
            _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Returns((User)null);

            // Act
            var result = _controller.LoginUser(loginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
            var unauthorizedResult = (UnauthorizedObjectResult)result;
            Assert.IsInstanceOfType(unauthorizedResult.Value, typeof(ErrorResponse));
        }

        [TestMethod]
        public void LoginUser_UnexpectedException_ReturnsInternalServerErrorResultWithErrorResponse()
        {
            // Arrange
            var loginRequest = new LoginUserDTO {  };
            _mockAccountService.Setup(service => service.LoginUser(loginRequest)).Throws(new Exception());

            // Act
            var result = _controller.LoginUser(loginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(500, objectResult.StatusCode);
            Assert.IsInstanceOfType(objectResult.Value, typeof(ErrorResponse));
        }*/
    }
}
