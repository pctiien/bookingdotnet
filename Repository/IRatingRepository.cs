using bookingdotcom.Models;
using bookingdotcom.ResponseModels;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IRatingRepository 
    {
        Task<Rating?> CreateRating(RatingModel model);
        Task<List<RatingResponseModel>> GetRatingsByLocationId(int locationId);
    }
}