using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("room_typenames")]
    public class RoomTypeName
    {
        [Column("roomtypename_id")]
        [Key]
        [JsonIgnore]
        public int RoomTypeNameId{set;get;}
        [Column("roomtypename")]        
        [Required]
        public string Room_TypeName{set;get;}="";
        [JsonIgnore]
        public virtual RoomType? RoomTypes{set;get;}
    }
}