using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IDiscountRepository
    {
        Task<Discount?> CreateDiscount(DiscountModel model);
    }
}