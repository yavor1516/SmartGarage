using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartGarage.Models.DTO
{
    public class VehicleDTO
    {
        [Required(ErrorMessage = "The {0} field is required!")]
        public Manufacturer? Manufacturer { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public CarModel? CarModel { get; set; }

    }
}
