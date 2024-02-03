using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Models.DTO
{
    public class LoginUserDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}