using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SmartGarage.Models
{
    public class LinkedVehicleService
    {
        [Key]
        public int LVServiceID { get; set; }


        [ForeignKey("LinkedVehicleID")]
        public int? LinkedVehicleID { get; set; } // Foreign Key
        public LinkedVehicles LinkedVehicle { get; set; }

        [ForeignKey("ServiceID")]
        public int? ServiceID { get; set; } // Foreign Key
        public Service Service { get; set; }
    

        [AllowNull]
        public bool? Status { get; set; } //notStarted=null , inProgress=false, Ready=true


    }
}
