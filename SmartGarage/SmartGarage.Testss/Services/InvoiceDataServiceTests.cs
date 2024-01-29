using Moq;
using SmartGarage.Exceptions;
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
    public class InvoiceDataServiceTests
    {
        private Mock<IInvoiceRepository> mockRepo;
        private InvoiceDataService service;
        private Invoice testInvoice;

        [TestInitialize]
        public void Initialize()
        {
            mockRepo = new Mock<IInvoiceRepository>();
            service = new InvoiceDataService(mockRepo.Object);
            testInvoice = new Invoice { /* Initialize with test data */ };
        }

        [TestMethod]
        public void CreateInvoice_ShouldReturnInvoice_WhenInvoiceIsValid()
        {
            // Arrange
            mockRepo.Setup(repo => repo.CreateInvoice(testInvoice)).Returns(testInvoice);

            // Act
            var result = service.CreateInvoice(testInvoice);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testInvoice, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateInvoice_ShouldThrowArgumentNullException_WhenInvoiceIsNull()
        {
            // Act
            service.CreateInvoice(null);
        }

        [TestMethod]
        public void GetAllInvoices_ShouldReturnInvoices_WhenCalled()
        {
            // Arrange
            var invoices = new List<Invoice> { testInvoice };
            mockRepo.Setup(repo => repo.GetAllInvoices()).Returns(invoices);

            // Act
            var result = service.GetAllInvoices();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        // ... Add other test methods for GetInvoiceByEmail, GetInvoiceByEmployeeID, etc.
        [TestMethod]
        public void GetInvoiceByEmail_ShouldReturnInvoice_WhenEmailIsValid()
        {
            // Arrange
            var email = "test@example.com";
            mockRepo.Setup(repo => repo.GetInvoiceByEmail(email)).Returns(testInvoice);

            // Act
            var result = service.GetInvoiceByEmail(email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testInvoice, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetInvoiceByEmail_ShouldThrowArgumentException_WhenEmailIsInvalid()
        {
            // Act
            service.GetInvoiceByEmail(string.Empty);
        }

        [TestMethod]
        public void GetInvoiceByEmployeeID_ShouldReturnInvoice_WhenEmployeeIDIsValid()
        {
            // Arrange
            int employeeId = 1;
            mockRepo.Setup(repo => repo.GetInvoiceByEmployeeID(employeeId)).Returns(testInvoice);

            // Act
            var result = service.GetInvoiceByEmployeeID(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testInvoice, result);
        }

        [TestMethod]
        public void GetInvoiceById_ShouldReturnInvoice_WhenInvoiceIdIsValid()
        {
            // Arrange
            int invoiceId = 1;
            mockRepo.Setup(repo => repo.GetInvoiceById(invoiceId)).Returns(testInvoice);

            // Act
            var result = service.GetInvoiceById(invoiceId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testInvoice, result);
        }

        [TestMethod]
        public void GetInvoiceByUserID_ShouldReturnInvoice_WhenUserIDIsValid()
        {
            // Arrange
            int userId = 1;
            mockRepo.Setup(repo => repo.GetInvoiceByUserID(userId)).Returns(testInvoice);

            // Act
            var result = service.GetInvoiceByUserID(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testInvoice, result);
        }

        [TestMethod]
        public void UpdateInvoice_ShouldCallUpdate_WhenInvoiceExists()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetInvoiceById(testInvoice.InvoiceId)).Returns(testInvoice);
            mockRepo.Setup(repo => repo.UpdateInvoice(testInvoice));

            // Act
            service.UpdateInvoice(testInvoice);

            // Assert
            mockRepo.Verify(repo => repo.UpdateInvoice(testInvoice), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void UpdateInvoice_ShouldThrowEntityNotFoundException_WhenInvoiceDoesNotExist()
        {
            // Arrange
            var nonExistingInvoice = new Invoice { InvoiceId = 99 };
            mockRepo.Setup(repo => repo.GetInvoiceById(nonExistingInvoice.InvoiceId)).Returns((Invoice)null);

            // Act
            service.UpdateInvoice(nonExistingInvoice);
        }
    }
}
