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


        [TestMethod]
        public void GetEmployeeByEmail_NullOrWhitespaceEmail_ThrowsArgumentException()
        {
            // Arrange
            string invalidEmail = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _employeeDataService.GetEmployeeByEmail(invalidEmail));
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
        public void GetEmployeeById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _employeeDataService.GetEmployeeByID(invalidId));
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
