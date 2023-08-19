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
        public int LocationId { get; set; }
        [Required]
        [Column("room_size")]
        public float RoomSize{set;get;}
        [Column("price")]
        [Required] 
        public float Price {set;get;}

        [JsonIgnore]
        [ForeignKey("LocationId")]
        public virtual Location? Location { get; set; }
        public virtual ICollection<UnavailableDate?>? UnvailableDates{get;set;}
        public virtual ICollection<RoomFacilityLink?>? BedTypes{set;get;}
        public virtual ICollection<RoomImage?>? RoomImages{set;get;}
        public virtual ICollection<RoomFacilityLink>? RoomFacilityLinks{set;get;}
    }   
}