using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class CarModel
    {

        [Key]

        public int CarModelID { get; set; }

        [Required]

        public string? Model { get; set; }

        [ForeignKey("ManufacturerID")]

        public int? ManufacturerID { get; set; } // Foreign Key

        public Manufacturer Manufacturer { get; set; }

    }


