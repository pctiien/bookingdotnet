using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("ratings")]
    public class Rating
    {
        [Key]
        [Column("rating_id")]
        public int RatingId { get; set; }
        [Column("user_id")]
        [Required]
        public int UserId{set;get;}
        [Required]
        [Column("rating_comment")]
        public string Comment { get; set; }="";
        [Column("rating_date")]
        public DateTime? RatingDate {set;get;}  
        [Required]
        [Column("rating_value")]
        public float Score { get; set; }
        [Required]
        [Column("location_id")]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")] // Định nghĩa khóa ngoại đến bảng "locations"
        [JsonIgnore]
        public virtual Location? Location { get; set; }
        [ForeignKey("UserId")] // Định nghĩa khóa ngoại đến bảng "locations"
        [JsonIgnore]
        public virtual User? User{set;get;}
    }
}