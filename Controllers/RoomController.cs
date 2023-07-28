using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookingdotcom.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RoomController : ControllerBase
    {
        public IRoomService _IRoomService {set;get;}
        public RoomController(IRoomService IRoomService)
        {
            _IRoomService = IRoomService;
        }
        [HttpPost("{location_id}")]
        public async Task<IActionResult> CreateRoom(int location_id,RoomModel model)
        {
            try
            {
                var room = await _IRoomService.CreateRoom(location_id,model);
                return Ok(room);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}