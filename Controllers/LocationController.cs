using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookingdotcom.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LocationController : ControllerBase
    {
        public ILocationService _ILocationService;
        public LocationController(ILocationService ILocationService)
        {
            _ILocationService = ILocationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocation(string destination)
        {
            try
            {
                var locations = await _ILocationService.GetLocation(destination);
                return Ok(locations);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationModel model)
        {
            try
            {
                var location = await _ILocationService.Create(model);
                return Ok(location);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}