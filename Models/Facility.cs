using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("facilities")]
    public class Facility 
    {
        [Key]
        [Column("facility_id")]
        public int RoomFacilityId{set;get;}
        [Column("facility_type")]
        [Required]
        public string RoomFacilityType{set;get;}="";
        public virtual ICollection<RoomFacilityLink>? RoomFacilityLinks{set;get;}
    }
}           