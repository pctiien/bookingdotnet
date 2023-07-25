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
        public string HashedPassword ="";

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [Column("email")]
        public string Email="";

        [MaxLength(20)]
        [Column("phone")]
        public string Phone="";
        [Column("date_of_birth")]

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        [Column("country")]
        public string Country="";

        [MaxLength(255)]
        [Column("display_name")]
        public string DisplayName="";
        [Column("salutation")]

        public bool? Salutation { get; set; }

        [MaxLength(50)]
        [Column("last_name")]
        public string LastName="";

        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName="";

        [MaxLength(200)]
        [Column("address")]
        public string Address="";

        [MaxLength(100)]
        [Column("city")]
        public string City="";

        [MaxLength(100)]
        [Column("postal_code")]
        public string PostalCode="";
    }

}