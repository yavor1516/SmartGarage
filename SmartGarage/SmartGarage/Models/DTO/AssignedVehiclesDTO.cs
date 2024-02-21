namespace SmartGarage.Models.DTO
{
    public class AssignedVehiclesDTO
    {         //.Include(c => c.LinkedVehicles)
              //                    .ThenInclude(m=>m.Manufacturer)
              //                    .ThenInclude(mod=>mod.CarModels)
              //                    .Include(c => c.LinkedVehicles)
              //                    .ThenInclude(e=>e.Employee)
              //                     .Include(c => c.LinkedVehicles)
              //                    .ThenInclude(i=>i.Invoice)
              //                     .Include(c => c.LinkedVehicles)
              //                         .ThenInclude(s => s.LinkedVehicleServices)
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public string EmployeeName { get; set; }

        public string LicensePlate { get; set; }
        public string WinNumber { get; set; }

        public int yearOfCreation { get; set; }

        public ICollection<LinkedVehicleServiceDTO> services { get; set; }




    }
}
