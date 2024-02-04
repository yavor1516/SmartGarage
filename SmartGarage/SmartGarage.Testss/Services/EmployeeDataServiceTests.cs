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
    public class EmployeeDataServiceTests
    {

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void CreateEmployee_DuplicateUserID_ThrowsException()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(r => r.GetEmployeeByEmail(It.IsAny<string>()))
                .Returns(new Employee {UserID=2});
            var employeeService = new EmployeeDataService(mockRepository.Object);
            var duplicateEmployee = new Employee { UserID = 2 };

            // Act
            employeeService.CreateEmployee(duplicateEmployee);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateEmployee_NullEmployee_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeDataService(mockRepository.Object);
            Employee nullEmployee = null;

            // Act
            employeeService.CreateEmployee(nullEmployee);
        }

        [TestMethod]
        public void GetAllEmployees_ReturnsListOfEmployees()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(r => r.GetAllEmployees())
                .Returns(new List<Employee> {});
            var employeeService = new EmployeeDataService(mockRepository.Object);

            // Act
            var employees = employeeService.GetAllEmployees();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetEmployeeById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(r => r.GetEmployeeById(It.IsAny<int>()))
                .Returns((Employee)null);
            var employeeService = new EmployeeDataService(mockRepository.Object);
            var invalidId = -1;

            // Act
            employeeService.GetEmployeeById(invalidId);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateEmployee_NonExistingEmployee_ThrowsInvalidOperationException()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(r => r.GetEmployeeById(It.IsAny<int>()))
                .Returns((Employee)null);
            var employeeService = new EmployeeDataService(mockRepository.Object);
            var nonExistingEmployee = new Employee {};

            // Act
            employeeService.UpdateEmployee(nonExistingEmployee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateEmployee_NullEmployee_ThrowsArgumentNullException()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeDataService(mockRepository.Object);
            Employee nullEmployee = null;

            // Act
            employeeService.UpdateEmployee(nullEmployee);
        }

        [TestMethod]
        public void GetEmployeeByEmail_ValidEmail_ReturnsEmployee()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(r => r.GetEmployeeByEmail(It.IsAny<string>()))
                .Returns(new Employee {});
            var employeeService = new EmployeeDataService(mockRepository.Object);
            var validEmail = "test@example.com";

            // Act
            var employee = employeeService.GetEmployeeByEmail(validEmail);
        }
    }
}

