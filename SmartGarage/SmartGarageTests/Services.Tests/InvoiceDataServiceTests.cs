using Moq;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
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
    public class InvoiceDataServiceTests
    {
        private Mock<IInvoiceRepository> _invoiceRepositoryMock;
        private InvoiceDataService _invoiceDataService;

        [TestInitialize]
        public void Setup()
        {
            _invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            _invoiceDataService = new InvoiceDataService(_invoiceRepositoryMock.Object);
        }

        [TestMethod]
        public void GetInvoiceById_ValidId_ReturnsInvoiceDTO()
        {
            // Arrange
            int id = 1;
            var invoiceEntity = new Invoice { InvoiceId = id, UserID = 1, EmployeeID = 1, LinkedVehicles = new List<LinkedVehicles>() };
            _invoiceRepositoryMock.Setup(repo => repo.GetInvoiceById(id)).Returns(invoiceEntity);

            // Act
            var result = _invoiceDataService.GetInvoiceById(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(invoiceEntity.InvoiceId, result.InvoiceID);
            Assert.AreEqual(invoiceEntity.UserID, result.UserID);
            Assert.AreEqual(invoiceEntity.EmployeeID, result.EmployeeID);
            CollectionAssert.AreEqual(invoiceEntity.LinkedVehicles.ToList(), result.LinkedVehicles.ToList());
        }

        [TestMethod]
        public void GetInvoiceById_InvalidId_ThrowsArgumentException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _invoiceDataService.GetInvoiceById(invalidId));
        }

        [TestMethod]
        public void GetInvoiceByEmail_ValidEmail_ReturnsListOfInvoiceDTO()
        {
            // Arrange
            string email = "test@example.com";
            var invoiceEntities = new List<Invoice> { new Invoice { InvoiceId = 1, UserID = 1, EmployeeID = 1, LinkedVehicles = new List<LinkedVehicles>() } };
            _invoiceRepositoryMock.Setup(repo => repo.GetInvoiceByEmail(email)).Returns(invoiceEntities);

            // Act
            var result = _invoiceDataService.GetInvoiceByEmail(email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(invoiceEntities.Count, result.Count);
            CollectionAssert.AreEqual(invoiceEntities.Select(i => i.InvoiceId).ToList(), result.Select(i => i.InvoiceID).ToList());
        }

        [TestMethod]
        public void GetInvoiceByEmail_NullOrEmptyEmail_ThrowsArgumentException()
        {
            // Arrange
            string invalidEmail = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _invoiceDataService.GetInvoiceByEmail(invalidEmail));
        }

        [TestMethod]
        public void UpdateInvoice_ValidInvoiceDTO_NoExceptionThrown()
        {
            // Arrange
            var invoiceDTO = new InvoiceDTO { InvoiceID = 1, UserID = 1, EmployeeID = 1, LinkedVehicles = new List<LinkedVehiclesDTO>() };
            var existingInvoiceEntity = new Invoice { InvoiceId = 1, UserID = 1, EmployeeID = 1, LinkedVehicles = new List<LinkedVehicles>() };
            _invoiceRepositoryMock.Setup(repo => repo.GetInvoiceById(invoiceDTO.InvoiceID)).Returns(existingInvoiceEntity);

            // Act
            _invoiceDataService.UpdateInvoice(invoiceDTO);

            // Assert
            _invoiceRepositoryMock.Verify(repo => repo.UpdateInvoice(It.IsAny<Invoice>()), Times.Once);
        }

        [TestMethod]
        public void UpdateInvoice_NullInvoiceDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _invoiceDataService.UpdateInvoice(null));
        }

        [TestMethod]
        public void UpdateInvoice_InexistentInvoice_ThrowsEntityNotFoundException()
        {
            // Arrange
            var invoiceDTO = new InvoiceDTO { InvoiceID = 1, UserID = 1, EmployeeID = 1, LinkedVehicles = new List<LinkedVehiclesDTO>() };
            _invoiceRepositoryMock.Setup(repo => repo.GetInvoiceById(invoiceDTO.InvoiceID)).Returns((Invoice)null);

            // Act & Assert
            Assert.ThrowsException<EntityNotFoundException>(() => _invoiceDataService.UpdateInvoice(invoiceDTO));
        }

    }
}

