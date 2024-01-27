using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Invoice
    {

        [Key]
        public int InvoiceId { get; set; }

        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("EmployeeID")]
        public int? EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public ICollection<LinkedVehicles>? LinkedVehicles { get; set; }

    }

