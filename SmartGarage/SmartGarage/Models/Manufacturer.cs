using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {

        [Key]

        public int ManufacturerID { get; set; }

        [Required]

        public string? BrandName { get; set; }

        public ICollection<CarModel>? CarModels { get; set; }

    }
