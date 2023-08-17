using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("room_facilities")]
    public class RoomFacility 
    {
        [Key]
        [Column("roomfacility_id")]
        public int RoomFacilityId{set;get;}
        [Column("roomfacility_type")]
        [Required]
        public string RoomFacilityType{set;get;}="";
        [Column("room_id")]
        [Required]
        public int RoomId{set;get;}
        [ForeignKey("RoomId")]
        [JsonIgnore]
        public virtual ICollection<Room?>? Rooms{set;get;}
    }
}           