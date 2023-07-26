using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("hashed_password")]
        public string HashedPassword{set;get;} ="";

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [Column("email")]
        public string Email{set;get;} ="";
        [MaxLength(20)]
        [Column("phone")]
        public string? Phone { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        [Column("country")]
        public string? Country { get; set; }

        [MaxLength(255)]
        [Column("display_name")]
        public string? DisplayName { get; set; }

        [Column("salutation")]
        public bool? Salutation { get; set; }

        [MaxLength(50)]
        [Column("last_name")]
        public string? LastName { get; set; }

        [MaxLength(50)]
        [Column("first_name")]
        public string? FirstName { get; set; }

        [MaxLength(200)]
        [Column("address")]
        public string? Address { get; set; }

        [MaxLength(100)]
        [Column("city")]
        public string? City { get; set; }

        [MaxLength(100)]
        [Column("postal_code")]
        public string? PostalCode { get; set; }

    }

}