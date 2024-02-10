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

        public ICollection<Invoice> GetInvoiceByEmail(string email)
        {
            var invoice = _dbcontext.Invoices.Where(x => x.User.Email == email).ToList();
            return invoice;
        }

        public ICollection<Invoice> GetInvoiceByEmployeeID(int id)
        {
            var invoice = _dbcontext.Invoices.Where(x => x.EmployeeID == id).ToList();
            return invoice;
        }

        public Invoice GetInvoiceById(int id)
        {
            Invoice invoice = _dbcontext.Invoices.FirstOrDefault(x => x.InvoiceId == id);
            return invoice;
        }

        public ICollection<Invoice> GetInvoiceByUserID(int id)
        {
            var invoice = _dbcontext.Invoices.Where(x => x.UserID == id).ToList();
            return invoice;
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _dbcontext.SaveChanges();
        }
    }
}
