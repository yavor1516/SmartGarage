namespace SmartGarage.Models.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

        public int? UserID { get; set; }

        public ICollection<VehicleDTO>? VehiclesCreated { get; set; }

        public ICollection<LinkedVehiclesDTO>? LinkedVehiclesCreated { get; set; }

        public bool IsAdmin { get; set; }
    }
}
