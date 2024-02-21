namespace SmartGarage.Models.DTO
{
    public class CustomerDTO
    {

        public int CustomerID { get; set; }

        public int? UserID { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }

        public ICollection<int>? LinkedVehicleIDs { get; set; }
    }
}
