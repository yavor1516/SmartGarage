using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        public User User { get; set; }
        public ICollection<LinkedVehicles>? LinkedVehicles { get; set; }
        //todo viewDates




    }
