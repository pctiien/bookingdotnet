using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("discounts")]
    public class Discount
    {
        [Key]
        [Column("discount_id")]
        public int DiscountId { get; set; }


        [Column("discount_amount",TypeName ="decimal(10,2)")]
        [Required]
        public decimal DiscountAmount { get; set; }

        [Required]
        [Column("discount_startdate")]
        public DateTime DiscountStartDate { get; set; }

        [Required]
        [Column("discount_enddate")]
        public DateTime DiscountEndDate { get; set; }

        [Required]
        [Column("location_id")]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        [JsonIgnore]
        public virtual Location? Location { get; set; }
    }
}