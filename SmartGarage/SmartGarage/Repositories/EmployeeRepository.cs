using Castle.Core.Resource;
using SmartGarage.Repositories.Contracts;

namespace SmartGarage.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GarageContext _dbcontext;

        public EmployeeRepository(GarageContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public Employee CreateEmployee(Employee employee)
        {
            _dbcontext.Employees.Add(employee);
            _dbcontext.SaveChanges();
            return employee;
        }

        public ICollection<Employee> GetAllEmployees()
        {
            return _dbcontext.Employees.ToList();
        }

        public Employee GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByFirstName(string firstName)
        {
            Employee employee = _dbcontext.Employees.FirstOrDefault(x => x.User.FirstName == firstName);
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = _dbcontext.Employees.FirstOrDefault(x => x.EmployeeID == id);
            return employee;
        }

        public Employee GetEmployeeByUserId(int id)
        {
            Employee employee = _dbcontext.Employees.FirstOrDefault(x => x.UserID == id);
            return employee;
        }

        public Employee GetEmployeeByUsername(string username)
        {
            Employee employee = _dbcontext.Employees.FirstOrDefault(x => x.User.Username == username);
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
             _dbcontext.SaveChanges();
        }
    }
}
