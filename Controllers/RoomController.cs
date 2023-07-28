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
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomModel model)
        {
            try
            {
                var room = await _IRoomService.CreateRoom(model);
                return Ok(room);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}