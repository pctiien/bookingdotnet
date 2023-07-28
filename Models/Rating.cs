using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("rating")]
    public class Rating
    {
        [Key]
        [Column("rating_id")]
        public int RatingId { get; set; }

        [Required]
        [Column("review")]
        public string Review { get; set; }="";

        [Required]
        [Column("score")]
        public float Score { get; set; }
        [Required]
        [Column("location_id")]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")] // Định nghĩa khóa ngoại đến bảng "locations"
        [JsonIgnore]
        public virtual Location? Location { get; set; }
    }
}