using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class LinkedVehicles
    {

        [Key]

        public int LinkedVehiclelID { get; set; }

        [Required]

        public string? Model { get; set; }

        [ForeignKey("VehicleID")]

        public int? VehicleID { get; set; } // Foreign Key

        public Vehicle Vehicle { get; set; }

        [ForeignKey("EmployeeID")]

        public int? EmployeeID { get; set; } // Foreign Key

        public Employee Employee { get; set; }

        [ForeignKey("CustomerID")]

        public int? CustomerID { get; set; } // Foreign Key

        public Customer Customer { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(8)] // Adjust according to the license plate 
        public string LicensePlate { get; set; }
        [Required]
        [StringLength(17)]
        public string VIN { get; set; }
        [Required]
        [Range(1887, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1887.")]
        public int YearOfCreation { get; set; }

        [ForeignKey("ServiceID")]
        public int? ServiceID { get; set; }
        public Service Service { get; set; }
        public ICollection<Service>? Services { get; set; }


    }
