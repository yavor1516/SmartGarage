using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Models.DTO
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }
        public int EmployeeID { get; set; }        

        [Required(ErrorMessage = "The {0} field is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} field is required!")]
        [Range(0, float.MaxValue, ErrorMessage = "The {0} must be greater than or equal to {1}.")]
        public decimal Price { get; set; }
    }
}
