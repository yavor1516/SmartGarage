using Moq;
using SmartGarage.Services.Contracts;
using SmartGarage.Services.TokenGenerator;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGarage.Helpers.Contracts;
using ForumSystem.Exceptions;
using SmartGarage.Models.DTO;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class AccountServiceTests
    {
        private Mock<IUserDataService> _userDataServiceMock;
        private Mock<IPasswordHasher> _passwordHasherMock;
        private Mock<AccessTokenGenerator> _tokenGeneratorMock;
        private AccountService _accountService;

        [TestInitialize]
        public void Setup()
        {
            _userDataServiceMock = new Mock<IUserDataService>();
            _passwordHasherMock = new Mock<IPasswordHasher>();
            _tokenGeneratorMock = new Mock<AccessTokenGenerator>();

            _accountService = new AccountService(
                _userDataServiceMock.Object,
                _passwordHasherMock.Object,
                _tokenGeneratorMock.Object
            );
        }

        [TestMethod]
        public void GenerateToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var user = new User { /* create a valid user object */ };
            _tokenGeneratorMock.Setup(t => t.GenerateToken(user)).Returns("dummy-token");

            // Act
            string token = _accountService.GenerateToken(user);

            // Assert
            Assert.AreEqual("dummy-token", token);
        }

        [TestMethod]
        public void LoginUser_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var userLoginDTO = new LoginUserDTO { /* provide valid login credentials */ };
            var user = new User { /* create a valid user object */ };
            _userDataServiceMock.Setup(u => u.GetByEmail(userLoginDTO.Email)).Returns(user);
            _passwordHasherMock.Setup(p => p.VerifyPassword(userLoginDTO.Password, It.IsAny<string>())).Returns(true);

            // Act
            User result = _accountService.LoginUser(userLoginDTO);

            // Assert
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong credentials!!")]
        public void LoginUser_IncorrectEmail_ThrowsException()
        {
            // Arrange
            var userLoginDTO = new LoginUserDTO { /* provide invalid login credentials */ };
            _userDataServiceMock.Setup(u => u.GetByEmail(userLoginDTO.Email)).Returns((User)null);

            // Act
            _accountService.LoginUser(userLoginDTO);

            // No Assert needed as we're expecting an exception
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong credentials!!")]
        public void LoginUser_IncorrectPassword_ThrowsException()
        {
            // Arrange
            var userLoginDTO = new LoginUserDTO { /* provide valid email */ };
            var user = new User { /* create a valid user object */ };
            _userDataServiceMock.Setup(u => u.GetByEmail(userLoginDTO.Email)).Returns(user);
            _passwordHasherMock.Setup(p => p.VerifyPassword(userLoginDTO.Password, It.IsAny<string>())).Returns(false);

            // Act
            _accountService.LoginUser(userLoginDTO);

            // No Assert needed as we're expecting an exception
        }

        [TestMethod]
        public void RegisterUser_NewUser_SuccessfullyRegisters()
        {
            // Arrange
            var registerUserDTO = new RegisterUserDTO { /* provide valid registration data */ };
            _userDataServiceMock.Setup(u => u.GetByEmail(registerUserDTO.Email)).Returns((User)null);
            _passwordHasherMock.Setup(p => p.HashPassword(It.IsAny<string>())).Returns("dummy-hash");

            // Act
            User result = _accountService.RegisterUser(registerUserDTO);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(registerUserDTO.Email, result.Email);
            // Add more assertions as needed
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntityException), "Account with email: {email} already exists!")]
        public void RegisterUser_ExistingUser_ThrowsException()
        {
            // Arrange
            var registerUserDTO = new RegisterUserDTO { /* provide valid registration data */ };
            _userDataServiceMock.Setup(u => u.GetByEmail(registerUserDTO.Email)).Returns(new User());

            // Act
            _accountService.RegisterUser(registerUserDTO);

            // No Assert needed as we're expecting an exception
        }
    }
}
