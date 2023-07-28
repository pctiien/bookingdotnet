using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("rooms")]
    public class Room
    {
        [Key]
        [Column("room_id")]
        public int RoomId { get; set; }

        [Required]
        [Column("room_name")]
        [MaxLength(100)]
        public string RoomName { get; set; }="";

        [Required]
        [Column("location_id")]
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [JsonIgnore]
        public virtual Location? Location { get; set; }
        public virtual ICollection<UnavailableDate?>? UnvailableDates{get;set;}
        public virtual ICollection<BedType?>? BedTypes{set;get;}
    }
}