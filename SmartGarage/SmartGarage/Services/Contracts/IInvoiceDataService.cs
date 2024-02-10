using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IInvoiceDataService
    {
        InvoiceDTO CreateInvoice(InvoiceDTO invoiceDTO);
        ICollection<InvoiceDTO> GetAllInvoices();
        ICollection<InvoiceDTO> GetInvoiceByEmail(string email);
        ICollection<InvoiceDTO> GetInvoiceByEmployeeID(int employeeId);
        InvoiceDTO GetInvoiceById(int invoiceId);
        ICollection<InvoiceDTO> GetInvoiceByUserID(int userId);
        void UpdateInvoice(InvoiceDTO invoiceDTO);
    }
}
