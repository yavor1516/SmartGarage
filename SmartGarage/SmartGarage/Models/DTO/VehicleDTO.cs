using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarage.Models.DTO
{
    public class VehicleDTO
    {
        public int VehicleID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public Manufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public CarModel? CarModel { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public Employee? Employee { get; set; }
    }
}
