using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class RoomBedModel
    {

        [Required]
        public int BedQuantity { get; set; }
    }
}