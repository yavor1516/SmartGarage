using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Models.DTO
{
    public class ManufacturerDTO
    {
        public int ManufacturerID { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        public string? BrandName { get; set; }

        public ICollection<CarModelDTO>? CarModels { get; set; }
    }
}
