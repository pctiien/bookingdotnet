using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookingdotcom.Models
{
    [Table("room_imgs")]
    public class RoomImg
{
    // Khóa chính được tự động sinh khi thêm mới bản ghi
    [Key]
    [Column("roomimg_id")]
    public int RoomImageId { get; set; }

    // URL của ảnh phòng (sử dụng kiểu dữ liệu TEXT)
    [Required]
    [Url]
    [Column("roomimg_url")]
    public string RoomImageUrl { get; set; }="";

    // Khóa ngoại liên kết với bảng 'rooms'
    [Required]
    [Column("roomtype_id")]
    public int RoomTypeId { get; set; }

    // Thuộc tính ForeignKey để xác định khóa ngoại
    [ForeignKey("RoomTypeId")]
    [JsonIgnore]
    public virtual RoomType? RoomType { get; set; }
}
}