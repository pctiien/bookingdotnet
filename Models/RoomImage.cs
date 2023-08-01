using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.Models
{
    [Table("room_images")]
    public class RoomImage
{
    // Khóa chính được tự động sinh khi thêm mới bản ghi
    [Key]
    [Column("roomimage_id")]
    public int RoomImageId { get; set; }

    // URL của ảnh phòng (sử dụng kiểu dữ liệu TEXT)
    [Required]
    [Url]
    [Column("roomimage_url")]
    public string RoomImageUrl { get; set; }="";

    // Khóa ngoại liên kết với bảng 'rooms'
    [Required]
    [Column("room_id")]
    public int RoomId { get; set; }

    // Thuộc tính ForeignKey để xác định khóa ngoại
    [ForeignKey("RoomId")]
    public virtual Room? Room { get; set; }
}
}