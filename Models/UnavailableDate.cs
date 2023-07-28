using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("unavailable_dates")]
    public class UnavailableDate
    {
        [Key]
        [Column("unavailable_id")]
        public int UnavailableId { get; set; }

        [Column("unavailable_date")]
        [Required]
        public DateTime Unavailable_Date { get; set; }

        [Column("room_id")]
        [ForeignKey("Room")]
        [Required]
        public int RoomId { get; set; }
        [JsonIgnore]

        public virtual Room? Room { get; set; }
    }
}