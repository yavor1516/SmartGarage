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


namespace SmartGarage.Tests.Services
{
    [TestClass]
    public class InvoiceDataServiceTests
    {
        private Mock<IInvoiceRepository> mockRepo;
        private InvoiceDataService service;
        private InvoiceDTO testInvoiceDTO;

        [TestInitialize]
        public void Initialize()
        {
            mockRepo = new Mock<IInvoiceRepository>();
            service = new InvoiceDataService(mockRepo.Object);
            testInvoiceDTO = new InvoiceDTO {};
        }

        [TestMethod]
        public void CreateInvoice_ShouldReturnInvoiceDTO_WhenInvoiceDTOIsValid()
        {
            // Arrange
            mockRepo.Setup(repo => repo.CreateInvoice(It.IsAny<Invoice>())).Returns(new Invoice());

            // Act
            var result = service.CreateInvoice(testInvoiceDTO);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateInvoice_ShouldThrowArgumentNullException_WhenInvoiceDTOIsNull()
        {
            // Act
            service.CreateInvoice(null);
        }

        [TestMethod]
        public void GetAllInvoices_ShouldReturnListOfInvoiceDTOs_WhenCalled()
        {
            // Arrange
            var invoices = new List<Invoice> { new Invoice() };
            mockRepo.Setup(repo => repo.GetAllInvoices()).Returns(invoices);

            // Act
            var result = service.GetAllInvoices();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void UpdateInvoice_ShouldCallUpdate_WhenInvoiceExists()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetInvoiceById(It.IsAny<int>())).Returns(new Invoice());
            mockRepo.Setup(repo => repo.UpdateInvoice(It.IsAny<Invoice>()));

            // Act
            service.UpdateInvoice(testInvoiceDTO);

            // Assert
            mockRepo.Verify(repo => repo.UpdateInvoice(It.IsAny<Invoice>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void UpdateInvoice_ShouldThrowEntityNotFoundException_WhenInvoiceDoesNotExist()
        {
            // Arrange
            var nonExistingInvoiceDTO = new InvoiceDTO { InvoiceID = 99 };
            mockRepo.Setup(repo => repo.GetInvoiceById(nonExistingInvoiceDTO.InvoiceID)).Returns((Invoice)null);

            // Act
            service.UpdateInvoice(nonExistingInvoiceDTO);
        }
    }
}
