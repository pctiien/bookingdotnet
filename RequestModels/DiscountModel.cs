using System.ComponentModel.DataAnnotations;

namespace bookingdotcom.ViewModels
{
    public class DiscountModel
    {
        [Required(ErrorMessage ="Discount amount is required")]
        public decimal DiscountAmount { get; set; }
        [Required(ErrorMessage ="Start date is required")]

        public DateTime DiscountStartDate { get; set; }
        [Required(ErrorMessage ="End date is required")]
        public DateTime DiscountEndDate { get; set; }
        [Required(ErrorMessage ="Location id is required")]
        public int LocationId{set;get;}
    }
}