using System.ComponentModel.DataAnnotations;

    public class User
    {

        [Key]

        public int UserID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(32)]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(32)]
        public string? LastName { get; set; }



        public byte[] PasswordHash { get; set; }

        public bool isOnline { get; set; }

        [Required]
        [StringLength(10)]
        public string? phoneNumber { get; set; } // This property allows nulls
        public DateTime RegistrationDate { get; set; }

    }
