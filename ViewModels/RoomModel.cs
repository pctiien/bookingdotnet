using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookingdotcom.Models;

namespace bookingdotcom.ViewModels
{
    public class RoomModel
    {

        [Required]
        public string RoomName { get; set; }="";
        public IFormFile[]? RoomImages{set;get;}
        public virtual ICollection<BedTypeModel?>? BedTypes{set;get;}
    }
}