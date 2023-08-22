using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookingdotcom.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class RoomTypeController : ControllerBase
    {
        public IRoomTypeService _IRoomTypeService {set;get;}
        public RoomTypeController(IRoomTypeService IRoomTypeService)
        {
            _IRoomTypeService = IRoomTypeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoomType([FromQuery]RoomTypeModel model)
        {
            try
            {
                var res = await _IRoomTypeService.CreateRoomType(model);
                return Ok(res);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}