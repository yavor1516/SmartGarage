namespace SmartGarage.Models.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }

        public int? UserID { get; set; }

        public ICollection<LinkedVehicles>? LinkedVehicles { get; set; }
    }
}
