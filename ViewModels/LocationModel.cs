using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookingdotcom.ViewModels
{
    public class LocationModel
    {
        [Required(ErrorMessage ="Location name is required")]
        public string LocationName { get; set; }="";

        [Required(ErrorMessage ="Address is required")]

        public string Address { get; set; }="";

        [Required(ErrorMessage ="Country is required")]
        public string Country{set;get;}="";

        [Required(ErrorMessage ="City is required")]
        public string City { get; set; }="";

        public string Description { get; set; }="";

    }
}