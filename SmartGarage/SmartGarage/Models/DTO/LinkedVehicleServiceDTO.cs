using System.Diagnostics.CodeAnalysis;

namespace SmartGarage.Models.DTO
{
    public class LinkedVehicleServiceDTO
    {
        public int LinkedVehicleID { get; set; }
        public int ServiceID { get; set; }
 
        public string Status { get; set; }
        public string ServiceName { get; set; }
    }
}
