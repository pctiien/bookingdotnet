using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public class RatingService : IRatingService
    {
        public IRatingRepository _IRatingRepository{set;get;}
        public RatingService(IRatingRepository IRatingRepository)
        {
            _IRatingRepository = IRatingRepository;
        }
        public async Task<Rating?> CreateRating(RatingModel model)
        {
            return await _IRatingRepository.CreateRating(model);
        }
    }
}