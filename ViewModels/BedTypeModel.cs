using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class BedTypeModel
    {

        [Required]
        public string BedTypeName { get; set; }="";
        
        
        public virtual RoomBedModel? RoomBed{set;get;}
    }
}