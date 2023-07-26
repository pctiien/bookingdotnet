using bookingdotcom.Models;
using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookingdotcom.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        public IUserService _IUserService;
        public AuthController(IUserService IUserServices)
        {
            _IUserService = IUserServices;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            try
            {
                User? user = await _IUserService.Register(model);
                return Ok(user);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}