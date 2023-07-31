using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public interface IRatingRepository 
    {
        Task<Rating?> CreateRating(RatingModel model);
        Task<List<Rating>> GetRatingsByLocationId(int locationId);
    }
}