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
        [HttpPost("register")]
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var jwtToken = await _IUserService.Login(model);
                return Ok(jwtToken);
            }
            catch (System.Exception)
            {
                return BadRequest("Wrong email or password.");
            }
        }
    }
}