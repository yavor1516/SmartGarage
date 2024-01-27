using Castle.Core.Resource;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly GarageContext _dbcontext;

        public InvoiceRepository(GarageContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Invoice CreateInvoice(Invoice invoice)
        {
            _dbcontext.Invoices.Add(invoice);
            _dbcontext.SaveChanges();
            return invoice;
        }

        public ICollection<Invoice> GetAllInvoices()
        {
            return _dbcontext.Invoices.ToList();
        }

        public Invoice GetInvoiceByEmail(string email)
        {
            Invoice invoice = _dbcontext.Invoices.FirstOrDefault(x => x.User.Email == email);
            return invoice;
        }

        public Invoice GetInvoiceByEmployeeID(int id)
        {
            Invoice invoice = _dbcontext.Invoices.FirstOrDefault(x => x.EmployeeID == id);
            return invoice;
        }

        public Invoice GetInvoiceById(int id)
        {
            Invoice invoice = _dbcontext.Invoices.FirstOrDefault(x => x.InvoiceId == id);
            return invoice;
        }

        public Invoice GetInvoiceByUserID(int id)
        {
            Invoice invoice = _dbcontext.Invoices.FirstOrDefault(x => x.UserID == id);
            return invoice;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _dbcontext.SaveChanges();
        }
    }
}
