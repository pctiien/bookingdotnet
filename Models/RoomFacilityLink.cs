using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("room_facility_links")]
    public class RoomFacilityLink
    {
        [Column("room_id")] 
        public int RoomId { get; set; }

        [Column("roomfacility_id")]
        public int FacilityId { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }
        [ForeignKey("FacilityId")]
        public virtual Facility? Facility { get; set; }
    }
}
