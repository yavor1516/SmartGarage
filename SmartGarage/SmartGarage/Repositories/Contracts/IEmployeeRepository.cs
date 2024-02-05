namespace SmartGarage.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployeeByID(int id);
        public Employee GetEmployeeByUserID(int id);
        public Employee GetEmployeeByFirstName(string firstName);
        public Employee GetEmployeeByUsername(string username);
        public Employee GetEmployeeByEmail(string email);
        public ICollection<Employee> GetAllEmployees();
        public Employee CreateEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
    }
}
