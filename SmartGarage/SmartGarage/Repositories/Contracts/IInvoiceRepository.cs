namespace SmartGarage.Repositories.Contracts
{
    public interface IInvoiceRepository
    {
        public Invoice GetInvoiceById(int id);
        public ICollection<Invoice> GetInvoiceByUserID(int id);
        public ICollection<Invoice> GetInvoiceByEmployeeID(int id);
        public ICollection<Invoice> GetInvoiceByEmail(string email);
        public ICollection<Invoice> GetAllInvoices();
        public Invoice CreateInvoice(Invoice invoice);
        public void UpdateInvoice(Invoice invoice);
    }
}
