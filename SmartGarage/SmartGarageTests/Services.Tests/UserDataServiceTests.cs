using Moq;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class UserDataServiceTests
    {
        private Mock<IUserRepository> _repositoryMock;
        private IUserDataService _userDataService;

        [TestInitialize]
        public void Setup()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _userDataService = new UserDataService(_repositoryMock.Object);
        }

        [TestMethod]
        public void GetByEmail_ValidEmail_ReturnsUser()
        {
            // Arrange
            string userEmail = "test@example.com";
            var expectedUser = new User { Email = userEmail /* Add other properties as needed */ };
            _repositoryMock.Setup(repo => repo.GetUserByEmail(userEmail)).Returns(expectedUser);

            // Act
            var result = _userDataService.GetByEmail(userEmail);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Email, result.Email);
            // Add assertions for other properties
        }


        [TestMethod]
        public void GetByUsername_ValidUsername_ReturnsUser()
        {
            // Arrange
            string username = "testuser";
            var expectedUser = new User { Username = username /* Add other properties as needed */ };
            _repositoryMock.Setup(repo => repo.GetUserByUsername(username)).Returns(expectedUser);

            // Act
            var result = _userDataService.GetByUsername(username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Username, result.Username);
            // Add assertions for other properties
        }

        [TestMethod]
        public void CreateUser_ValidUser_ReturnsCreatedUser()
        {
            // Arrange
            var user = new User { /* fill with test data */ };
            var expectedUser = new User { /* fill with expected data */ };
            _repositoryMock.Setup(repo => repo.CreateUser(user , true)).Returns(expectedUser);

            // Act
            var result = _userDataService.CreateUser(user , true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, result);
            // Add more specific assertions if needed
        }
    }
}
