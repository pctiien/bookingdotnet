using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("locations")]
    public class Location
    {
        [Key]
        [Column("location_id")]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("location_name")]
        public string LocationName { get; set; }="";
        [Required]
        [MaxLength(50)]
        [Column("country")]
        public string Country{set;get;}="";

        [MaxLength(100)]
        [Column("address")]
        public string Address { get; set; }="";

        [MaxLength(50)]
        [Column("city")]
        public string City { get; set; }="";
        [Column("description")]

        public string Description { get; set; }="";
        public virtual Discount? Discount{set;get;}
        public virtual ICollection<Rating?>? Ratings{set;get;}

    }
}