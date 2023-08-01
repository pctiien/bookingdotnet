using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("location_images")]
    public class LocationImage
{
    // Khóa chính được tự động sinh khi thêm mới bản ghi
    [Key]
    [Column("locationimage_id")]
    public int LocationImageId { get; set; }

    // URL của ảnh (sử dụng kiểu dữ liệu TEXT)
    [Column("locationimage_url")]
    [Required]
    [Url]
    public string LocationImageUrl { get; set; }="";

    // Khóa ngoại liên kết với bảng 'locations'
    [Column("location_id")]
    [Required]
    public int LocationId { get; set; }

    // Thuộc tính ForeignKey để xác định khóa ngoại
    [ForeignKey("LocationId")]
    [JsonIgnore]
    public virtual Location? Location { get; set; }
}
}