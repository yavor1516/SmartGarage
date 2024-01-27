using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Vehicle
    {
        [Key]

        public int VehicleID { get; set; }

        [ForeignKey("ManufacturerId")]
        public int? ManufacturerId { get; set; } // Foreign Key
        public Manufacturer Manufacturer { get; set; }

        [ForeignKey("CarModelID")]
        public int? CarModelID { get; set; } // Foreign Key
        public CarModel CarModel { get; set; }

        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; } // Foreign Key
        public Employee Employee { get; set; }


    }
