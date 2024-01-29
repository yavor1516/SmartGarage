namespace SmartGarage.Services.Contracts
{
    public interface IInvoiceDataService
    {
        Invoice CreateInvoice(Invoice invoice);
        ICollection<Invoice> GetAllInvoices();
        Invoice GetInvoiceByEmail(string email);
        Invoice GetInvoiceByEmployeeID(int employeeId);
        Invoice GetInvoiceById(int invoiceId);
        Invoice GetInvoiceByUserID(int userId);
        void UpdateInvoice(Invoice invoice);
    }
}
