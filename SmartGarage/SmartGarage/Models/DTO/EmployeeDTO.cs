namespace SmartGarage.Models.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

        public int? UserID { get; set; }

        public string Email { get;set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string phonenumber { get; set; }

        public ICollection<VehicleDTO>? VehiclesCreated { get; set; }

        public ICollection<LinkedVehiclesDTO>? LinkedVehiclesCreated { get; set; }

        public bool IsAdmin { get; set; }
    }
}
