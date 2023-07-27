using bookingdotcom.Services;
using bookingdotcom.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookingdotcom.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DiscountController : ControllerBase
    {
        public IDiscountService _IDiscountService{set;get;}
        public DiscountController(IDiscountService IDiscountService)
        {
            _IDiscountService = IDiscountService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(DiscountModel model)
        {
            try
            {
                var discount =await _IDiscountService.CreateDiscount(model);
                return Ok(discount);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }
    }
}