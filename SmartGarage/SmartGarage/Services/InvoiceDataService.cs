using SmartGarage.Exceptions;
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

        public Invoice CreateInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }
            return _invoiceRepository.CreateInvoice(invoice);
        }

        public ICollection<Invoice> GetAllInvoices()
        {
            return _invoiceRepository.GetAllInvoices();
        }

        public Invoice GetInvoiceByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            return _invoiceRepository.GetInvoiceByEmail(email);
        }

        public Invoice GetInvoiceByEmployeeID(int employeeId)
        {
            return _invoiceRepository.GetInvoiceByEmployeeID(employeeId);
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            return _invoiceRepository.GetInvoiceById(invoiceId);
        }

        public Invoice GetInvoiceByUserID(int userId)
        {
            return _invoiceRepository.GetInvoiceByUserID(userId);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            var existingInvoice = _invoiceRepository.GetInvoiceById(invoice.InvoiceId);
            if (existingInvoice == null)
            {
                throw new EntityNotFoundException("Invoice not found.");
            }
            _invoiceRepository.UpdateInvoice(invoice);
        }
    }
}
