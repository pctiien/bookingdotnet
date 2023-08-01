using bookingdotcom.Attributes;
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
        [HttpGet("{location_id}/images")]
        public async Task<IActionResult> GetLocationImgs(int location_id)
        {
            try
            {
                var listImgs = await _ILocationService.GetLocationImgList(location_id);
                if(listImgs!=null)
                {
                    return Ok(listImgs);
                }else return BadRequest("Couldn't get this location");
            }
            catch (System.Exception)
            {
                return BadRequest("Couldn't get this location");
            }
        }

        
        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> CreateLocation([FromForm]LocationModel model)
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