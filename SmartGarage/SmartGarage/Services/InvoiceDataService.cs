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

            var invoice = new Invoice
            {
                UserID = invoiceDTO.UserID,
                EmployeeID = invoiceDTO.EmployeeID,
                LinkedVehicles = (ICollection<LinkedVehicles>)invoiceDTO.LinkedVehicles
            };

            var createdInvoice = _invoiceRepository.CreateInvoice(invoice);

            return MapInvoiceToDTO(createdInvoice);
        }

        public ICollection<InvoiceDTO> GetAllInvoices()
        {
            var invoices = _invoiceRepository.GetAllInvoices();

            return invoices.Select(MapInvoiceToDTO).ToList();
        }

        public InvoiceDTO GetInvoiceByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            var invoice = _invoiceRepository.GetInvoiceByEmail(email);

            return MapInvoiceToDTO(invoice);
        }

        public InvoiceDTO GetInvoiceByEmployeeID(int employeeId)
        {
            var invoice = _invoiceRepository.GetInvoiceByEmployeeID(employeeId);

            return MapInvoiceToDTO(invoice);
        }

        public InvoiceDTO GetInvoiceById(int invoiceId)
        {
            var invoice = _invoiceRepository.GetInvoiceById(invoiceId);

            return MapInvoiceToDTO(invoice);
        }

        public InvoiceDTO GetInvoiceByUserID(int userId)
        {
            var invoice = _invoiceRepository.GetInvoiceByUserID(userId);

            return MapInvoiceToDTO(invoice);
        }

        public void UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO == null)
            {
                throw new ArgumentNullException(nameof(invoiceDTO));
            }

            var invoice = new Invoice
            {
                InvoiceId = invoiceDTO.InvoiceID,
                UserID = invoiceDTO.UserID,
                EmployeeID = invoiceDTO.EmployeeID,
            };

            var existingInvoice = _invoiceRepository.GetInvoiceById(invoice.InvoiceId);
            if (existingInvoice == null)
            {
                throw new EntityNotFoundException("Invoice not found.");
            }

            _invoiceRepository.UpdateInvoice(invoice);
        }

        private InvoiceDTO MapInvoiceToDTO(Invoice invoice)
        {
            return new InvoiceDTO
            {
                InvoiceID = invoice.InvoiceId,
                UserID = invoice.UserID,
                EmployeeID = invoice.EmployeeID,
                LinkedVehicles = (ICollection<LinkedVehiclesDTO>)invoice.LinkedVehicles
            };
        }
    }
}
