using bookingdotcom.Models;
using bookingdotcom.ResponseModels;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface IRatingService
    {
        Task<Rating?> CreateRating(RatingModel model);
        Task<List<RatingResponseModel>> GetRatings(int locationId);
    }
}