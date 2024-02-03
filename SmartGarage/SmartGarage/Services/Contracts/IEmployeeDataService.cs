namespace SmartGarage.Services.Contracts
{
    public interface IEmployeeDataService
    {
        Employee CreateEmployee(Employee employee);
        ICollection<Employee> GetAllEmployees();
        Employee GetEmployeeByEmail(string email);
        Employee GetEmployeeByFirstName(string firstName);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByUserId(int id);
        Employee GetEmployeeByUsername(string username);
        void UpdateEmployee(Employee employee);
    }
}
