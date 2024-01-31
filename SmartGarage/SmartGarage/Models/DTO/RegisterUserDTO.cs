using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Models.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "The {0} field must be a valid email address.")]
        public string Email { get; set; }
    }
}
