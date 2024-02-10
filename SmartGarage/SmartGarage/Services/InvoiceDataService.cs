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

        public ICollection<InvoiceDTO> GetInvoiceByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            var invoice = _invoiceRepository.GetInvoiceByEmail(email);

            return invoice.Select(MapInvoiceToDTO).ToList();
        }

        public ICollection<InvoiceDTO> GetInvoiceByEmployeeID(int employeeId)
        {
            
            var invoice = _invoiceRepository.GetInvoiceByEmployeeID(employeeId);

            return invoice.Select(MapInvoiceToDTO).ToList();
        }

        public InvoiceDTO GetInvoiceById(int invoiceId)
        {
            var invoice = _invoiceRepository.GetInvoiceById(invoiceId);

            return MapInvoiceToDTO(invoice);
        }

        public ICollection<InvoiceDTO> GetInvoiceByUserID(int userId)
        {
            var invoice = _invoiceRepository.GetInvoiceByUserID(userId);

            return invoice.Select(MapInvoiceToDTO).ToList();
        }

        public void UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO == null)
            {
                throw new ArgumentNullException(nameof(invoiceDTO));
            }

            var invoiceEntity = MapInvoiceDTOToEntity(invoiceDTO);
            var existingInvoice = _invoiceRepository.GetInvoiceById(invoiceEntity.InvoiceId);

            if (existingInvoice == null)
            {
                throw new EntityNotFoundException("Invoice not found.");
            }

            existingInvoice.InvoiceId=invoiceEntity.InvoiceId;
            existingInvoice.UserID = invoiceEntity.UserID;
            existingInvoice.EmployeeID=invoiceEntity.EmployeeID;

            _invoiceRepository.UpdateInvoice(existingInvoice);
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
        private Invoice MapInvoiceDTOToEntity(InvoiceDTO invoiceDTO)
        {
            return new Invoice
            {
                InvoiceId = invoiceDTO.InvoiceID,
                UserID = invoiceDTO.UserID,
                EmployeeID = invoiceDTO.EmployeeID,
                LinkedVehicles = (ICollection<LinkedVehicles>)invoiceDTO.LinkedVehicles
            };
        }
    }
}
