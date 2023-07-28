using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("roombeds")]
    public class RoomBed
    {
        [Key]
        [Column("roombed_id")]
        public int RoomBedId { get; set; }

        [Required]
        [Column("bed_quantity")]
        public int BedQuantity { get; set; }

        [Required]
        [Column("bedtype_id")]
        [ForeignKey("BedType")]
        public int BedTypeId { get; set; }
        
        [JsonIgnore]
        public virtual BedType? BedType { get; set; }
    }
}