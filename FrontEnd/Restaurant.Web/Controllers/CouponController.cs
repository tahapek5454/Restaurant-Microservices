using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models.Dtos.Coupon;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Controllers
{
    public class CouponController(ICouponService _couponService) : Controller
    {
        public async Task<IActionResult> CouponIndex()
        {
            var result = await _couponService.GetAllCouponAsync();

            if(result is null || !result.IsSuccessful)
            {
                TempData["error"] = result?.Error?.Errors.First().ToString();
                return RedirectToAction("Index", "Home");
            }

            TempData["success"] = "Success";
            return View(result.Data);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponCreateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
               

            var result  = await _couponService.CreateCouponAsync(model);

            if(result is not null || result.IsSuccessful) 
                return RedirectToAction(nameof(CouponIndex));


            TempData["error"] = result?.Error?.Errors.First().ToString();

            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {

            var result  = await _couponService.DeleteCouponAsync(couponId);

            if(!result.IsSuccessful)
                TempData["error"] = result?.Error?.Errors.First().ToString();

            return RedirectToAction(nameof(CouponIndex));
        }

    }
}
