using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        public readonly BookingDbContext _DbContext;
        public DiscountRepository(BookingDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<Discount?> CreateDiscount(DiscountModel model)
        {
            var discount = new Discount{
                DiscountAmount = model.DiscountAmount,
                DiscountEndDate = model.DiscountEndDate,
                DiscountStartDate = model.DiscountStartDate,
                LocationId = model.LocationId
            };
            await _DbContext.Discounts.AddAsync(discount);
            await _DbContext.SaveChangesAsync();
            return discount;
        }
    }
}