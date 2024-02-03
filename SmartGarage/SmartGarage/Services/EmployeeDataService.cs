using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDataService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

             var existingEmployee = _employeeRepository.GetEmployeeByEmail(employee.User.Email);
             if (existingEmployee != null)
             {
                 throw new InvalidOperationException("Employee with the same email already exists.");
             }

            return _employeeRepository.CreateEmployee(employee);
        }

        public ICollection<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return _employeeRepository.GetEmployeeByEmail(email);
        }

        public Employee GetEmployeeByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }
            return _employeeRepository.GetEmployeeByFirstName(firstName);
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            return _employeeRepository.GetEmployeeById(id);
        }

        public Employee GetEmployeeByUserId(int id)
        {
            return _employeeRepository.GetEmployeeByUserId(id);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            }
            return _employeeRepository.GetEmployeeByUsername(username);
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

             var existingEmployee = _employeeRepository.GetEmployeeById(employee.EmployeeID);
             if (existingEmployee == null)
             {
                 throw new InvalidOperationException("Employee does not exist.");
             }

            _employeeRepository.UpdateEmployee(employee);
        }
    }
}
