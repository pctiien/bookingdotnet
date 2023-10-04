using bookingdotcom.Models;
using bookingdotcom.ResponseModels;
using bookingdotcom.ViewModels;
using Microsoft.EntityFrameworkCore;

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
                UserId = model.UserId,
                RatingDate = DateTime.Now,
                Score = model.Score,
                Comment = model.Review,
                LocationId = model.LocationId
            };
            await _DbContext.Ratings.AddAsync(rating);
            await _DbContext.SaveChangesAsync();
            return rating;
        }

        public async Task<List<RatingResponseModel>> GetRatingsByLocationId(int locationId)
        {
            var result = await _DbContext.Ratings.Where(r=>r.LocationId == locationId)
                                    .Select(r=>new RatingResponseModel{
                                        RatingId = r.RatingId,
                                        Comment = r.Comment,
                                        UserName = r.User!.DisplayName??"",
                                        UserCountry = r.User.Country??"",
                                        UserAvatar = ""
                                    }).Take(5).ToListAsync();
            return result;
        }
    }
}