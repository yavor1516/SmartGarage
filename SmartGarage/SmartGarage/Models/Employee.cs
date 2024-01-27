using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        public User User { get; set; }
        public ICollection<Vehicle>? VehiclesCreated { get; set; }
        public ICollection<LinkedVehicles>? LinkedVehiclesCreated { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

    }
