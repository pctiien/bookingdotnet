using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("room_bedtype_links")]
    public class RoomBedTypeLink 
    {
        [DefaultValue(1)]
        [Column("quantity")]
        public int Quantity {set;get;}
        [Column("room_id")]
        [Required]
        public int RoomId {set;get;}
        [Column("bedtype_id")]
        [Required]
        public int BedTypeId{set;get;}
        [ForeignKey("RoomId")]
        public virtual Room? Room{set;get;}
        [ForeignKey("BedTypeId")]
        public virtual BedType? BedType{set;get;}

    }
}