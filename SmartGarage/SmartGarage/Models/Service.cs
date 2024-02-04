using System.ComponentModel.DataAnnotations;

    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public decimal Price { get; set; }
    }
