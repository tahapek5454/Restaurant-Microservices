using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Controllers
{
    public class CouponController(ICouponService _couponService) : Controller
    {
        public async Task<IActionResult> CouponIndex()
        {
            var result = await _couponService.GetAllCouponAsync();

            if(result is null || result.IsSuccessful is false)
                return NotFound();

            return View(result.Data);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
    }
}
