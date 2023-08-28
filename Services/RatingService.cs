using bookingdotcom.Models;
using bookingdotcom.Repository;
using bookingdotcom.ResponseModels;
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

        public async Task<List<RatingResponseModel>> GetRatings(int locationId)
        {
            var ratingsList = await _IRatingRepository.GetRatingsByLocationId(locationId);
            return ratingsList;
        }
    }
}