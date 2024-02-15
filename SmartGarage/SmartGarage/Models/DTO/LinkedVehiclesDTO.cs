using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Models.DTO
{
    public class LinkedVehiclesDTO
    {
        public int LinkedVehiclelID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public int VehicleID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        [MinLength(6)]
        [MaxLength(8, ErrorMessage = "License plate must be between 6 and 8 characters.")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        [StringLength(17, ErrorMessage = "VIN must be 17 characters.")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        [Range(1887, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1887.")]
        public int YearOfCreation { get; set; }

        public ICollection<ServiceDTO>? Services { get; set; }
    }
}
