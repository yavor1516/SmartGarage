using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        [Required]
        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public bool Status { get; set; } //notStarted=null , inProgress=false, Ready=true

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public decimal Price { get; set; }
    }
