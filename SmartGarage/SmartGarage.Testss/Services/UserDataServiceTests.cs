using Moq;
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
    public class UserDataServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private UserDataService _userDataService;

        [TestInitialize]
        public void Initialize()
        {
            // Create a mock of IUserRepository
            _mockUserRepository = new Mock<IUserRepository>();

            // Initialize the service with the mocked repository
            _userDataService = new UserDataService(_mockUserRepository.Object);
        }

        [TestMethod]
        public void GetByEmail_WhenCalled_ShouldReturnUser()
        {
            // Arrange
            var email = "test@example.com";
            var expectedUser = new User { Email = email };
            _mockUserRepository.Setup(repo => repo.GetUserByEmail(email)).Returns(expectedUser);

            // Act
            var result = _userDataService.GetByEmail(email);

            // Assert
            Assert.AreEqual(expectedUser, result);
            _mockUserRepository.Verify(repo => repo.GetUserByEmail(email), Times.Once);
        }

        [TestMethod]
        public void GetByUsername_WhenCalled_ShouldReturnUser()
        {
            // Arrange
            var username = "testuser";
            var expectedUser = new User { Username = username };
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(username)).Returns(expectedUser);

            // Act
            var result = _userDataService.GetByUsername(username);

            // Assert
            Assert.AreEqual(expectedUser, result);
            _mockUserRepository.Verify(repo => repo.GetUserByUsername(username), Times.Once);
        }

        [TestMethod]
        public void CreateUser_WhenCalled_ShouldCreateUser()
        {
            // Arrange
            var newUser = new User { /* set properties as needed */ };
            _mockUserRepository.Setup(repo => repo.CreateUser(newUser)).Returns(newUser);

            // Act
            var result = _userDataService.CreateUser(newUser);

            // Assert
            Assert.AreEqual(newUser, result);
            _mockUserRepository.Verify(repo => repo.CreateUser(newUser), Times.Once);
        }

        [TestMethod]
        public void GetByUsername_WithInvalidUsername_ShouldHandleGracefully()
        {
            // Arrange
            var invalidUsername = ""; // or a very long string, or a string with invalid characters
            _mockUserRepository.Setup(repo => repo.GetUserByUsername(invalidUsername)).Returns((User)null);

            // Act
            var result = _userDataService.GetByUsername(invalidUsername);

            // Assert
            Assert.IsNull(result); // or handle according to your application's logic
        }
    }
}
