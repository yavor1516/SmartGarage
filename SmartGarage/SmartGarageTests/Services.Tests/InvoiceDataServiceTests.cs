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
        public void GetInvoiceByEmail_NullOrEmptyEmail_ThrowsArgumentException()
        {
            // Arrange
            string invalidEmail = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _invoiceDataService.GetInvoiceByEmail(invalidEmail));
        }

        [TestMethod]
        public void UpdateInvoice_NullInvoiceDTO_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => _invoiceDataService.UpdateInvoice(null));
        }
    }
}

