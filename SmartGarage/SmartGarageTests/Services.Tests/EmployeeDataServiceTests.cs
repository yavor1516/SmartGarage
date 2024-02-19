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
    public class EmployeeDataServiceTests
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private EmployeeDataService _employeeDataService;

        [TestInitialize]
        public void Setup()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeDataService = new EmployeeDataService(_employeeRepositoryMock.Object);
        }

        // Existing test methods...

        [TestMethod]
        public void GetEmployeeByEmail_ValidEmail_ReturnsEmployeeDTO()
        {
            // Arrange
            string email = "test@example.com";
            var employeeEntity = new Employee { EmployeeID = 1, UserID = 1, VehiclesCreated = new List<Vehicle>(), LinkedVehiclesCreated = new List<LinkedVehicles>() };
            _employeeRepositoryMock.Setup(repo => repo.GetEmployeeByEmail(email)).Returns(employeeEntity);

            // Act
            var result = _employeeDataService.GetEmployeeByEmail(email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeEntity.EmployeeID, result.EmployeeID);
            Assert.AreEqual(employeeEntity.UserID, result.UserID);
            CollectionAssert.AreEqual(employeeEntity.VehiclesCreated.ToList(), result.VehiclesCreated.ToList());
            CollectionAssert.AreEqual(employeeEntity.LinkedVehiclesCreated.ToList(), result.LinkedVehiclesCreated.ToList());
        }

        [TestMethod]
        public void GetEmployeeByEmail_NullOrWhitespaceEmail_ThrowsArgumentException()
        {
            // Arrange
            string invalidEmail = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _employeeDataService.GetEmployeeByEmail(invalidEmail));
        }

        [TestMethod]
        public void GetEmployeeByFirstName_ValidFirstName_ReturnsEmployeeDTO()
        {
            // Arrange
            string firstName = "John";
            var employeeEntity = new Employee { EmployeeID = 1, UserID = 1, VehiclesCreated = new List<Vehicle>(), LinkedVehiclesCreated = new List<LinkedVehicles>() };
            _employeeRepositoryMock.Setup(repo => repo.GetEmployeeByFirstName(firstName)).Returns(employeeEntity);

            // Act
            var result = _employeeDataService.GetEmployeeByFirstName(firstName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeEntity.EmployeeID, result.EmployeeID);
            Assert.AreEqual(employeeEntity.UserID, result.UserID);
            CollectionAssert.AreEqual(employeeEntity.VehiclesCreated.ToList(), result.VehiclesCreated.ToList());
            CollectionAssert.AreEqual(employeeEntity.LinkedVehiclesCreated.ToList(), result.LinkedVehiclesCreated.ToList());
        }

        [TestMethod]
        public void GetEmployeeByFirstName_NullOrWhitespaceFirstName_ThrowsArgumentException()
        {
            // Arrange
            string invalidFirstName = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _employeeDataService.GetEmployeeByFirstName(invalidFirstName));
        }

        [TestMethod]
        public void GetEmployeeById_ValidId_ReturnsEmployeeDTO()
        {
            // Arrange
            int id = 1;
            var employeeEntity = new Employee { EmployeeID = id, UserID = 1, VehiclesCreated = new List<Vehicle>(), LinkedVehiclesCreated = new List<LinkedVehicles>() };
            _employeeRepositoryMock.Setup(repo => repo.GetEmployeeByID(id)).Returns(employeeEntity);

            // Act
            var result = _employeeDataService.GetEmployeeByID(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeEntity.EmployeeID, result.EmployeeID);
            Assert.AreEqual(employeeEntity.UserID, result.UserID);
            CollectionAssert.AreEqual(employeeEntity.VehiclesCreated.ToList(), result.VehiclesCreated.ToList());
            CollectionAssert.AreEqual(employeeEntity.LinkedVehiclesCreated.ToList(), result.LinkedVehiclesCreated.ToList());
        }

        [TestMethod]
        public void GetEmployeeById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _employeeDataService.GetEmployeeByID(invalidId));
        }

        [TestMethod]
        public void GetEmployeeByUsername_ValidUsername_ReturnsEmployeeDTO()
        {
            // Arrange
            string username = "testuser";
            var employeeEntity = new Employee { EmployeeID = 1, UserID = 1, VehiclesCreated = new List<Vehicle>(), LinkedVehiclesCreated = new List<LinkedVehicles>() };
            _employeeRepositoryMock.Setup(repo => repo.GetEmployeeByUsername(username)).Returns(employeeEntity);

            // Act
            var result = _employeeDataService.GetEmployeeByUsername(username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeEntity.EmployeeID, result.EmployeeID);
            Assert.AreEqual(employeeEntity.UserID, result.UserID);
            CollectionAssert.AreEqual(employeeEntity.VehiclesCreated.ToList(), result.VehiclesCreated.ToList());
            CollectionAssert.AreEqual(employeeEntity.LinkedVehiclesCreated.ToList(), result.LinkedVehiclesCreated.ToList());
        }

        [TestMethod]
        public void GetEmployeeByUsername_NullOrWhitespaceUsername_ThrowsArgumentException()
        {
            // Arrange
            string invalidUsername = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _employeeDataService.GetEmployeeByUsername(invalidUsername));
        }
    }
}
