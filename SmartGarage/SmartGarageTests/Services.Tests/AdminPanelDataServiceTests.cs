using Moq;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Services.Tests
{
    [TestClass]
    public class AdminPanelDataServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private AdminPanelDataService _adminPanelDataService;

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _adminPanelDataService = new AdminPanelDataService(_userRepositoryMock.Object);
        }

        [TestMethod]
        public void BlockUser_ValidUsername_UserBlocked()
        {
            // Arrange
            string username = "testUser";
            var userToBlock = new User { Username = username, isBlocked = false };
            _userRepositoryMock.Setup(r => r.GetUserByUsername(username)).Returns(userToBlock);

            // Act
            var result = _adminPanelDataService.BlockUser(username);

            // Assert
            Assert.IsTrue(result.isBlocked);
        }

        [TestMethod]
        public void UnBlockUser_ValidUsername_UserUnblocked()
        {
            // Arrange
            string username = "testUser";
            var userToUnblock = new User { Username = username, isBlocked = true };
            _userRepositoryMock.Setup(r => r.GetUserByUsername(username)).Returns(userToUnblock);

            // Act
            var result = _adminPanelDataService.UnBlockUser(username);

            // Assert
            Assert.IsFalse(result.isBlocked);
        }
        [TestMethod]
        public void BlockUser_NullUsername_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _adminPanelDataService.BlockUser(null));
        }

        [TestMethod]
        public void UnBlockUser_NullUsername_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _adminPanelDataService.UnBlockUser(null));
        }

        [TestMethod]
        public void BlockUser_UserNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            string username = "nonExistentUser";
            _userRepositoryMock.Setup(r => r.GetUserByUsername(username)).Returns((User)null);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => _adminPanelDataService.BlockUser(username));
        }

        [TestMethod]
        public void UnBlockUser_UserNotFound_ThrowsInvalidOperationException()
        {
            // Arrange
            string username = "nonExistentUser";
            _userRepositoryMock.Setup(r => r.GetUserByUsername(username)).Returns((User)null);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => _adminPanelDataService.UnBlockUser(username));
        }
    }
}
