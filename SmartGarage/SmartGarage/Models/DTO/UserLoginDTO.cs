using System.ComponentModel.DataAnnotations;

namespace SmartGarage.Models.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
