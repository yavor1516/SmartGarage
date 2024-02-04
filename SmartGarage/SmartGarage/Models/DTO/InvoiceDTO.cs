namespace SmartGarage.Models.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }

        public int? UserID { get; set; }

        public int? EmployeeID { get; set; }

        public ICollection<LinkedVehiclesDTO>? LinkedVehicles { get; set; }
    }
}
