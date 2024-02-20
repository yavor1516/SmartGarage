using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SmartGarage.Models.DTO
{
    public class CustomerProfileDTO
    {
  
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<AssignedVehiclesDTO> Vehicles { get; set; }
    }
}
