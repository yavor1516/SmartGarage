using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SmartGarage.Models.DTO
{
    public class CustomerProfileDTO
    {
        public string Username;
        public string Email;
        public string PhoneNumber;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<LinkedVehicles> Vehicles;
    }
}
