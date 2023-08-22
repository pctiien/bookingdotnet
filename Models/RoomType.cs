        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;
        using System.Text.Json.Serialization;

        namespace bookingdotcom.Models
        {
            [Table("room_types")]
            public class RoomType{
                [Column("roomtype_id")]
                [Key]
                public int RoomTypeId{set;get;}
                [Column("max_occupancy")]
                [Required]
                public int MaxOccupancy{set;get;}
                [Column("location_id")]
                [Required]
                public int LocationId{set;get;}
                [Column("roomtypename_id")]
                [Required]
                public int RoomTypeNameId{set;get;}
                [ForeignKey("LocationId")]
                [JsonIgnore]
                public virtual Location? Location{set;get;}
                [ForeignKey("RoomTypeNameId")]
                public virtual RoomTypeName? RoomTypeName{set;get;}
                public virtual ICollection<RoomImg>? RoomImages{set;get;}
            }
        }