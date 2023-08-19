using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class RatingModel
    {
        [Required]
        public int UserId{set;get;}

        [Required]
        public string Review { get; set; }="";

        [Required]
        [Range(1,5,ErrorMessage ="Score must be between 1 and 5")]
        public float Score { get; set; }

        [Required]
        public int LocationId { get; set; }

    }
}