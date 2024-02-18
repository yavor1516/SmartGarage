using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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

        [MinLength(4)]
        [MaxLength(32)]
        [AllowNull]
        public string? FirstName { get; set; }

        [MinLength(4)]
        [MaxLength(32)]
        [AllowNull]
    public string? LastName { get; set; }



        public byte[] PasswordHash { get; set; }

        public bool isOnline { get; set; }
        public bool isBlocked { get; set; }
        
        [StringLength(10)]
        [AllowNull]
        public string? phoneNumber { get; set; } // This property allows nulls
        public DateTime RegistrationDate { get; set; }

    }
