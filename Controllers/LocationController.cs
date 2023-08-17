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
        [HttpGet("{Location_id}")]
        public async Task<IActionResult> GetLocationById(int location_id)
        {
            try
            {
                var location = await _ILocationService.GetLocationById(location_id);
                return Ok(location);
            }
            catch (System.Exception)
            {
                return BadRequest("Couldn't get this location by this id");
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
        [HttpDelete("{location_id}")]
        public async Task<IActionResult> Delete(int location_id)
        {
            try
            {
                var res = await _ILocationService.Delete(location_id);
                if(res)
                {
                    return Ok();
                }else return NotFound();

            }
            catch (System.Exception)
            {
                return BadRequest("Location id must be a valid integer");
            }
        }
    }
}