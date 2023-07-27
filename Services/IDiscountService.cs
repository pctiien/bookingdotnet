using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface IDiscountService 
    {
        Task<Discount?> CreateDiscount(DiscountModel model); 
    }
}