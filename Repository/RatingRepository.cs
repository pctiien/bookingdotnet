using bookingdotcom.Models;
using bookingdotcom.ViewModels;

namespace bookingdotcom.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly BookingDbContext _DbContext;
        public RatingRepository(BookingDbContext BookingDbContext)
        {
            _DbContext = BookingDbContext; 
        }
        public async Task<Rating?> CreateRating(RatingModel model)
        {
            var rating = new Rating{
                Score = model.Score,
                Review = model.Review,
                LocationId = model.LocationId
            };
            await _DbContext.Ratings.AddAsync(rating);
            await _DbContext.SaveChangesAsync();
            return rating;
        }
    }
}