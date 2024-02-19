using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartGarage.Controllers.API;
using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarageTests.Controllers.Tests
{
    [TestClass]
    public class InvoiceControllerTests
    {
        private InvoiceController _controller;
        private Mock<IInvoiceDataService> _mockInvoiceService;

        [TestInitialize]
        public void Setup()
        {
            _mockInvoiceService = new Mock<IInvoiceDataService>();
            _controller = new InvoiceController(_mockInvoiceService.Object);
        }

        [TestMethod]
        public void GetAllInvoices_ReturnsOkResultWithInvoiceList()
        {
            // Arrange
            var invoices = new[] { new InvoiceDTO { /* fill with valid data */ } };
            _mockInvoiceService.Setup(service => service.GetAllInvoices()).Returns(invoices);

            // Act
            var result = _controller.GetAllInvoices();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
