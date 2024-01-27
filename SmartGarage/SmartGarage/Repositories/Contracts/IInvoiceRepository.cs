namespace SmartGarage.Repositories.Contracts
{
    public interface IInvoiceRepository
    {
        public Invoice GetInvoiceById(int id);
        public Invoice GetInvoiceByUserID(int id);
        public Invoice GetInvoiceByEmployeeID(int id);
        public Invoice GetInvoiceByEmail(string email);
        public ICollection<Invoice> GetAllInvoices();
        public Invoice CreateInvoice(Invoice invoice);
        public void UpdateInvoice(Invoice invoice);
    }
}
