using Moq;
using SmartGarage.Models.DTO;
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
    public class EmployeeDataServiceTests
    {
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private EmployeeDataService _employeeService;

        [TestInitialize]
        public void Initialize()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeDataService(_mockEmployeeRepository.Object);
        }

        [TestMethod]
        public void CreateEmployee_ValidEmployeeDTO_ReturnsCreatedEmployeeDTO()
        {
            // Arrange
            var employeeDTO = new EmployeeDTO
            {
                // Initialize with valid data
            };

            var expectedEmployeeEntity = new Employee
            {
                // Initialize with valid data
            };

            _mockEmployeeRepository
                .Setup(repo => repo.GetEmployeeByID(It.IsAny<int>()))
                .Returns((int id) =>
                {
                    // Simulate that employee with the same ID does not exist
                    return null;
                });

            _mockEmployeeRepository
                .Setup(repo => repo.CreateEmployee(It.IsAny<Employee>()))
                .Returns(expectedEmployeeEntity);

            // Act
            var result = _employeeService.CreateEmployee(employeeDTO);

            // Assert
            Assert.IsNotNull(result);
            // Add more assertions based on your logic
        }

        [TestMethod]
        public void CreateEmployee_DuplicateEmployee_ReturnsInvalidOperationException()
        {
            // Arrange
            var employeeDTO = new EmployeeDTO
            {
                // Initialize with valid data
            };

            var existingEmployeeEntity = new Employee
            {
                // Initialize with valid data
            };

            _mockEmployeeRepository
                .Setup(repo => repo.GetEmployeeByID(It.IsAny<int>()))
                .Returns(existingEmployeeEntity);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => _employeeService.CreateEmployee(employeeDTO));
        }
    }
}

