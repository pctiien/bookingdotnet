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
        [JsonIgnore]
        public int BedTypeId { get; set; }

        [Required]
        [Column("bedtype_name")]
        [MaxLength(50)]
        public string BedTypeName { get; set; }="";
        [JsonIgnore]
        public virtual ICollection<RoomTypeBedTypeLink>? RoomTypeBeds{set;get;}
    }
}