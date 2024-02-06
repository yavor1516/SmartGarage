using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarage.Models.DTO
{
    public class VehicleDTO
    {
        public int VehicleID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public string CarModel { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public int EmployeeID { get; set; }
    }
}
