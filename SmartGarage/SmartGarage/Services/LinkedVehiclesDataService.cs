using SmartGarage.Repositories.Contracts;
using SmartGarage.Services.Contracts;

namespace SmartGarage.Services
{
    public class LinkedVehiclesDataService:ILinkeeVehiclesDataService
    {
        private readonly ILinkedVehiclesRepository _linkedVehiclesRepository;

        public LinkedVehiclesDataService(ILinkedVehiclesRepository linkedVehiclesRepository)
        {
            _linkedVehiclesRepository = linkedVehiclesRepository ?? throw new ArgumentNullException(nameof(linkedVehiclesRepository));
        }

        public LinkedVehicles CreateLinkedVehicle(LinkedVehicles linkedVehicles)
        {
            if (linkedVehicles == null) throw new ArgumentNullException(nameof(linkedVehicles));
            // Validation for already existing vehicle                                                      //TODO

            return _linkedVehiclesRepository.CreateLinkedVehicle(linkedVehicles);
        }

        public LinkedVehicles GetLinkedVehicleByCustomerId(int customerId)
        {
            if (customerId <= 0) throw new ArgumentException("Customer ID must be greater than zero.", nameof(customerId));

            return _linkedVehiclesRepository.GetLinkedVehiclesByCustomerId(customerId);
        }

        public LinkedVehicles GetLinkedVehicleByCustomerName(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or whitespace.", nameof(customerName));

            return _linkedVehiclesRepository.GetLinkedVehiclesByCustomerName(customerName);
        }

        public LinkedVehicles GetLinkedVehicleByEmployeeId(int employeeId)
        {
            if (employeeId <= 0) throw new ArgumentException("Employee ID must be greater than zero.", nameof(employeeId));

            return _linkedVehiclesRepository.GetLinkedVehiclesByEmployeeId(employeeId);
        }

        public LinkedVehicles GetLinkedVehicleByEmployeeName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                throw new ArgumentException("Employee name cannot be null or whitespace.", nameof(employeeName));

            return _linkedVehiclesRepository.GetLinkedVehiclesByEmployeeName(employeeName);
        }

        public LinkedVehicles GetLinkedVehicleById(int id)
        {
            if (id <= 0) throw new ArgumentException("ID must be greater than zero.", nameof(id));

            return _linkedVehiclesRepository.GetLinkedVehiclesById(id);
        }

        public LinkedVehicles GetLinkedVehicleByLicensePlate(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("License plate cannot be null or whitespace.", nameof(licensePlate));

            return _linkedVehiclesRepository.GetLinkedVehiclesByLicensePlate(licensePlate);
        }

        public LinkedVehicles GetLinkedVehicleByModelName(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model name cannot be null or whitespace.", nameof(model));

            return _linkedVehiclesRepository.GetLinkedVehiclesByModelName(model);
        }

        public ICollection<LinkedVehicles> GetAllLinkedVehiclesById(int id)
        {
            if (id <= 0) throw new ArgumentException("ID must be greater than zero.", nameof(id));

            return _linkedVehiclesRepository.GetAllLinkedVehiclesById(id);
        }

        public void UpdateLinkedVehicle(LinkedVehicles linkedVehicles)
        {
            if (linkedVehicles == null) throw new ArgumentNullException(nameof(linkedVehicles));

            _linkedVehiclesRepository.UpdateLinkedVehicles(linkedVehicles);
        }
    }
}
