using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("bedtypes")]
    public class BedType
    {
        [Key]
        [Column("bedtype_id")]
        public int BedTypeId { get; set; }

        [Required]
        [Column("bedtype_name")]
        [MaxLength(50)]
        public string BedTypeName { get; set; }="";

        [Column("room_id")]
        [ForeignKey("Room")]
        [Required]
        public int RoomId { get; set; }
        
        [JsonIgnore]
        public virtual Room? Room { get; set; }
        public virtual RoomBed? RoomBed{get;set;}
    }
}