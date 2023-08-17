using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("room_facility_links")]
    public class RoomFacilityLink
    {
       // [Key]
        [Column("room_id")] 
        public int RoomId { get; set; }

       // [Key]
        [Column("roomfacility_id")]
        public int RoomFacilityId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }
        [ForeignKey("RoomFacilityId")]
        public virtual RoomFacility? RoomFacility { get; set; }
    }
}
