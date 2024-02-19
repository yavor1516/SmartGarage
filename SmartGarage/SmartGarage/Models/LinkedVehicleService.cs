using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SmartGarage.Models
{
    public class LinkedVehicleService
    {
        [Key]
        [Column(Order = 1)]
        public int LinkedVehicleID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ServiceID { get; set; }

        [AllowNull]
        public bool? Status { get; set; } //notStarted=null , inProgress=false, Ready=true

        // Navigation property to LinkedVehicles
        public LinkedVehicles LinkedVehicle { get; set; }

        // Navigation property to Service
        public Service Service { get; set; }
    }
}
