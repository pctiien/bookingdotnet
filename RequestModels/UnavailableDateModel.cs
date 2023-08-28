using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class UnavailableDateModel
    {
        [Required]
        public DateTime Unavailable_Date { get; set; }
    }
}