using SmartGarage.Models.DTO;
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

        public EmployeeDTO CreateEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                throw new ArgumentNullException(nameof(employeeDTO));
            }

            var existingEmployee = _employeeRepository.GetEmployeeByID(employeeDTO.EmployeeID);//TODO MUST BE EMAIL!!
            if (existingEmployee != null)
            {
                throw new InvalidOperationException("Employee with the same email already exists.");
            }

            var employeeEntity = MapEmployeeDTOToEntity(employeeDTO);
            var createdEmployee = _employeeRepository.CreateEmployee(employeeEntity);

            return MapEmployeeEntityToDTO(createdEmployee);
        }

        public ICollection<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();

            // Map the list of entities to DTOs
            return employees.Select(MapEmployeeEntityToDTO).ToList();
        }

        public EmployeeDTO GetEmployeeByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }

            var employeeEntity = _employeeRepository.GetEmployeeByEmail(email);

            // Map the Employee entity to DTO
            return MapEmployeeEntityToDTO(employeeEntity);
        }

        public EmployeeDTO GetEmployeeByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(firstName));
            }

            var employeeEntity = _employeeRepository.GetEmployeeByFirstName(firstName);

            return MapEmployeeEntityToDTO(employeeEntity);
        }

        public EmployeeDTO GetEmployeeByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var employeeEntity = _employeeRepository.GetEmployeeByID(id);

            return MapEmployeeEntityToDTO(employeeEntity);
        }

        public EmployeeDTO GetEmployeeByUserID(int id)
        {
            var employeeEntity = _employeeRepository.GetEmployeeByUserID(id);

            return MapEmployeeEntityToDTO(employeeEntity);
        }

        public EmployeeDTO GetEmployeeByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(username));
            }

            var employeeEntity = _employeeRepository.GetEmployeeByUsername(username);

            return MapEmployeeEntityToDTO(employeeEntity);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                throw new ArgumentNullException(nameof(employeeDTO));
            }

            var employeeEntity = MapEmployeeDTOToEntity(employeeDTO);

            var existingEmployee = _employeeRepository.GetEmployeeByID(employeeEntity.EmployeeID);
            if (existingEmployee == null)
            {
                throw new InvalidOperationException("Employee does not exist.");
            }

            _employeeRepository.UpdateEmployee(employeeEntity);
        }
        public Employee MapEmployeeDTOToEntity(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return null;
            }

            return new Employee
            {
                EmployeeID = employeeDTO.EmployeeID,
                UserID = employeeDTO.UserID,
                VehiclesCreated = (ICollection<Vehicle>)employeeDTO.VehiclesCreated,
                LinkedVehiclesCreated = (ICollection<LinkedVehicles>)employeeDTO.LinkedVehiclesCreated,
                IsAdmin = employeeDTO.IsAdmin
            };
        }
        public EmployeeDTO MapEmployeeEntityToDTO(Employee employeeEntity)
        {
            if (employeeEntity == null)
            {
                return null;
            }

            return new EmployeeDTO
            {
                EmployeeID = employeeEntity.EmployeeID,
                UserID = employeeEntity.UserID,
               Email = employeeEntity.User.Email,
               firstName = employeeEntity.User.FirstName,
               lastName = employeeEntity.User.LastName,
               username = employeeEntity.User.Username,
               phonenumber = employeeEntity.User.phoneNumber,
                VehiclesCreated = (ICollection<VehicleDTO>)employeeEntity.VehiclesCreated,
                LinkedVehiclesCreated = (ICollection<LinkedVehiclesDTO>)employeeEntity.LinkedVehiclesCreated,
                IsAdmin = employeeEntity.IsAdmin
            };
        }
    }
}
