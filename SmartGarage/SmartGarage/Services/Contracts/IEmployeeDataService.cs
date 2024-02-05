using SmartGarage.Models.DTO;

namespace SmartGarage.Services.Contracts
{
    public interface IEmployeeDataService
    {
        EmployeeDTO CreateEmployee(EmployeeDTO employeeDTO);
        ICollection<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeByEmail(string email);
        EmployeeDTO GetEmployeeByFirstName(string firstName);
        EmployeeDTO GetEmployeeByID(int id);
        EmployeeDTO GetEmployeeByUserID(int id);
        EmployeeDTO GetEmployeeByUsername(string username);
        EmployeeDTO MapEmployeeEntityToDTO(Employee employeeEntity);
        Employee MapEmployeeDTOToEntity(EmployeeDTO employeeDTO);
        void UpdateEmployee(EmployeeDTO employeeDTO);
    }
}