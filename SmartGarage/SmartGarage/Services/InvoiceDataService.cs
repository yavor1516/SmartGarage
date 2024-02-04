using SmartGarage.Exceptions;
using SmartGarage.Models.DTO;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class InvoiceDataService : IInvoiceDataService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceDataService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public InvoiceDTO CreateInvoice(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO == null)
            {
                throw new ArgumentNullException(nameof(invoiceDTO));
            }

            // Manually map properties from InvoiceDTO to Invoice
            var invoice = new Invoice
            {
                UserID = invoiceDTO.UserID,
                EmployeeID = invoiceDTO.EmployeeID,
                // Map other properties as needed
            };

            var createdInvoice = _invoiceRepository.CreateInvoice(invoice);

            // Map the created Invoice entity to InvoiceDTO
            return MapInvoiceToDTO(createdInvoice);
        }

        public ICollection<InvoiceDTO> GetAllInvoices()
        {
            var invoices = _invoiceRepository.GetAllInvoices();

            // Manually map list of Invoice to list of InvoiceDTO
            return invoices.Select(MapInvoiceToDTO).ToList();
        }

        public InvoiceDTO GetInvoiceByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            var invoice = _invoiceRepository.GetInvoiceByEmail(email);

            // Map the Invoice entity to InvoiceDTO
            return MapInvoiceToDTO(invoice);
        }

        public InvoiceDTO GetInvoiceByEmployeeID(int employeeId)
        {
            var invoice = _invoiceRepository.GetInvoiceByEmployeeID(employeeId);

            // Map the Invoice entity to InvoiceDTO
            return MapInvoiceToDTO(invoice);
        }

        public InvoiceDTO GetInvoiceById(int invoiceId)
        {
            var invoice = _invoiceRepository.GetInvoiceById(invoiceId);

            // Map the Invoice entity to InvoiceDTO
            return MapInvoiceToDTO(invoice);
        }

        public InvoiceDTO GetInvoiceByUserID(int userId)
        {
            var invoice = _invoiceRepository.GetInvoiceByUserID(userId);

            // Map the Invoice entity to InvoiceDTO
            return MapInvoiceToDTO(invoice);
        }

        public void UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO == null)
            {
                throw new ArgumentNullException(nameof(invoiceDTO));
            }

            // Manually map properties from InvoiceDTO to Invoice
            var invoice = new Invoice
            {
                InvoiceId = invoiceDTO.InvoiceID,
                UserID = invoiceDTO.UserID,
                EmployeeID = invoiceDTO.EmployeeID,
                // Map other properties as needed
            };

            var existingInvoice = _invoiceRepository.GetInvoiceById(invoice.InvoiceId);
            if (existingInvoice == null)
            {
                throw new EntityNotFoundException("Invoice not found.");
            }

            _invoiceRepository.UpdateInvoice(invoice);
        }

        // Helper method for mapping Invoice to InvoiceDTO
        private InvoiceDTO MapInvoiceToDTO(Invoice invoice)
        {
            return new InvoiceDTO
            {
                InvoiceID = invoice.InvoiceId,
                UserID = invoice.UserID,
                EmployeeID = invoice.EmployeeID,
               // LinkedVehicles = invoice.LinkedVehicles?.Select(MapLinkedVehiclesToDTO).ToList()  //TODO
            };
        }
    }
}
