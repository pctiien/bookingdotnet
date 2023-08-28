using bookingdotcom.Attributes;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookingdotcom.Controllers
{
    [ApiController]
    [Route("api/Location/Ratings")]
    public class RatingController : ControllerBase
    {
        public IRatingService _IRatingService{set;get;}
        public RatingController(IRatingService IRatingService)
        {
            _IRatingService = IRatingService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRating(RatingModel model){
            try
            {
                var rating = await _IRatingService.CreateRating(model);
                return Ok(rating);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRatings(int locationId)
        {
            try
            {
                var result = await _IRatingService.GetRatings(locationId);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest("Location Id must be a valid number");
            }
        }
    }
}