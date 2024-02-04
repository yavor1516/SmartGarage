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
    public class AuthControllerTests
    {
        [TestMethod]
        public void RegisterUser_ValidRegistration_ReturnsOk()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            var authController = new AuthController(mockAccountService.Object);

            var validRegistrationRequest = new RegisterUserDTO{};

            mockAccountService.Setup(s => s.RegisterUser(validRegistrationRequest))
                .Verifiable();

            // Act
            var result = authController.RegisterUser(validRegistrationRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void RegisterUser_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            var authController = new AuthController(mockAccountService.Object);

            var invalidRegistrationRequest = new RegisterUserDTO();

            authController.ModelState.AddModelError("Property", "ErrorMessage");

            // Act
            var result = authController.RegisterUser(invalidRegistrationRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void RegisterUser_DuplicateEntityException_ReturnsConflict()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            var authController = new AuthController(mockAccountService.Object);

            var duplicateRegistrationRequest = new RegisterUserDTO{};

            mockAccountService.Setup(s => s.RegisterUser(duplicateRegistrationRequest))
                .Throws(new DuplicateEntityException("Duplicate user"));

            // Act
            var result = authController.RegisterUser(duplicateRegistrationRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ConflictObjectResult));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterUser_ExceptionThrown_ReturnsConflict()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            var authController = new AuthController(mockAccountService.Object);

            var invalidRegistrationRequest = new RegisterUserDTO{};

            mockAccountService.Setup(s => s.RegisterUser(invalidRegistrationRequest))
                .Throws(new Exception("An exception occurred"));

            // Act and Assert
            authController.RegisterUser(invalidRegistrationRequest);
        }

        [TestMethod]
        public void LoginUser_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            var authController = new AuthController(mockAccountService.Object);

            var invalidLoginRequest = new LoginUserDTO{};

            mockAccountService.Setup(s => s.LoginUser(invalidLoginRequest))
                .Returns((User)null);

            // Act
            var result = authController.LoginUser(invalidLoginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }

        [TestMethod]
        public void LoginUser_UnexpectedException_ReturnsInternalServerError()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            var authController = new AuthController(mockAccountService.Object);

            var invalidLoginRequest = new LoginUserDTO{};

            mockAccountService.Setup(s => s.LoginUser(invalidLoginRequest))
                .Throws(new Exception("An unexpected exception occurred during login"));

            // Act
            var result = authController.LoginUser(invalidLoginRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objectResult = result as ObjectResult;
            Assert.AreEqual(500, objectResult.StatusCode);
        }
    }
}
