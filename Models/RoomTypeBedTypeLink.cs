using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("roomtype_bedtype_links")]
    public class RoomTypeBedTypeLink 
    {
        [DefaultValue(1)]
        [Column("quantity")]
        public int Quantity {set;get;}
        [Column("roomtype_id")]
        [Required]
        public int RoomTypeId {set;get;}
        [Column("bedtype_id")]
        [Required]
        public int BedTypeId{set;get;}
        [ForeignKey("BedTypeId")]
        public virtual BedType? BedType{set;get;}
        [ForeignKey("RoomTypeId")]
        public virtual RoomType? RoomType{set;get;}

    }
}