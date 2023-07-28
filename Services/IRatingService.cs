using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Services
{
    public interface IRatingService
    {
        Task<Rating?> CreateRating(RatingModel model);
    }
}