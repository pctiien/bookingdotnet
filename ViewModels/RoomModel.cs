using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using bookingdotcom.Models;

namespace bookingdotcom.ViewModels
{
    public class RoomModel
    {

        [Required]
        public string RoomName { get; set; }="";

        [Required]
        public int LocationId { get; set; }

        public virtual ICollection<UnavailableDateModel?>? UnavailableDates{get;set;}
        public virtual ICollection<BedTypeModel?>? BedTypes{set;get;}
    }
}