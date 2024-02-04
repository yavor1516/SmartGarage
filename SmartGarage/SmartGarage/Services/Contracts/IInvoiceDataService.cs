using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IInvoiceDataService
    {
        InvoiceDTO CreateInvoice(InvoiceDTO invoiceDTO);
        ICollection<InvoiceDTO> GetAllInvoices();
        InvoiceDTO GetInvoiceByEmail(string email);
        InvoiceDTO GetInvoiceByEmployeeID(int employeeId);
        InvoiceDTO GetInvoiceById(int invoiceId);
        InvoiceDTO GetInvoiceByUserID(int userId);
        void UpdateInvoice(InvoiceDTO invoiceDTO);
    }
}
