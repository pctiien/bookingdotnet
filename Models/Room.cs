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
        [Column("location_id")]
        public int LocationId { get; set; }
        [Required]
        [Column("room_size")]
        public float RoomSize{set;get;}
        [Column("price")]
        [Required] 
        public float Price {set;get;}
        [Column("roomtype_id")]
        [Required]
        public int RoomTypeId {set;get;}
        [ForeignKey("RoomTypeId")]
        public virtual RoomType? RoomType{set;get;}

        [JsonIgnore]
        [ForeignKey("LocationId")]
        public virtual Location? Location { get; set; }
        public virtual ICollection<UnavailableDate?>? UnvailableDates{get;set;}
        public virtual ICollection<RoomFacilityLink>? RoomFacilityLinks{set;get;}
    }   
}