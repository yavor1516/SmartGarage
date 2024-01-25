using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using SmartGarage.Repositories;

namespace SmartGarage.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        private Mock<GarageContext> _mockContext;
        private Mock<DbSet<User>> _mockSet;
        private UserRepository _userRepository;
        private List<User> _users;

        [TestInitialize]
        public void Initialize()
        {

            // Initialize the DbContext and DbSet Mocks
            _mockContext = new Mock<GarageContext>();
            _mockSet = new Mock<DbSet<User>>();

            // Seed with some test data
            _users = new List<User>
        {
            new User { UserID = 1, Email = "test1@example.com", FirstName = "Test", Username = "user1" },
            new User { UserID = 2, Email = "test2@example.com", FirstName = "Test", Username = "user2" }
            // ... more users
        };

            // Setup the DbSet Mock
            _mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(_users.AsQueryable().Provider);
            _mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(_users.AsQueryable().Expression);
            _mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(_users.AsQueryable().ElementType);
            _mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => _users.GetEnumerator());

            // Ensure that the context returns the DbSet Mock
            _mockContext.Setup(c => c.Users).Returns(_mockSet.Object);

            // Create the repository instance
            _userRepository = new UserRepository(_mockContext.Object);
        }

        [TestMethod]
        public void CreateUser_ShouldAddUser()
        {
            // Arrange
            var newUser = new User { UserID = 3, Email = "test3@example.com", FirstName = "Test", Username = "user3" };
            _mockSet.Setup(m => m.Add(It.IsAny<User>())).Callback<User>((s) => _users.Add(s));

            // Act
            var result = _userRepository.CreateUser(newUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, _users.Count); // Including the newly added user
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            // Act
            var result = _userRepository.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); // The initial user count
        }

        [TestMethod]
        public void GetUserByEmail_ShouldReturnUser()
        {
            // Arrange
            var emailToFind = "test1@example.com";

            // Act
            var result = _userRepository.GetUserByEmail(emailToFind);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(emailToFind, result.Email);
        }

        [TestMethod]
        public void GetUserById_WhenCalledWithExistingId_ShouldReturnCorrespondingUser()
        {
            // Arrange
            var idToFind = 1;

            // Act
            var result = _userRepository.GetUserById(idToFind);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(idToFind, result.UserID);
        }

        [TestMethod]
        public void GetUserByUsername_WhenCalledWithExistingUsername_ShouldReturnCorrespondingUser()
        {
            // Arrange
            var usernameToFind = "user1";

            // Act
            var result = _userRepository.GetUserByUsername(usernameToFind);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(usernameToFind, result.Username);
        }

        [TestMethod]
        public void UpdateUser_WhenCalledWithModifiedUser_ShouldSaveChanges()
        {
            // Arrange
            var userToUpdate = _users.First();
            userToUpdate.Email = "updated@example.com"; // Simulate a change to the user

            // Act
            _userRepository.UpdateUser(userToUpdate);

            // Assert
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
