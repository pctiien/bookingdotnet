using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public class DiscountService : IDiscountService
    {
        public IDiscountRepository _IDiscountRepository{set;get;}
        public DiscountService(IDiscountRepository IDiscountRepository)
        {
            _IDiscountRepository = IDiscountRepository;
        }
        public async Task<Discount?> CreateDiscount(DiscountModel model)
        {
            return await _IDiscountRepository.CreateDiscount(model);
        }

    }
}