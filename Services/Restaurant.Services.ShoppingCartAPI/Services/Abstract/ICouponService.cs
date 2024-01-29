using Restaurant.Services.ShoppingCartAPI.Models.Dtos;

namespace Restaurant.Services.ShoppingCartAPI.Services.Abstract
{
    public interface ICouponService
    {
        Task<CouponDto> GetCouponByCodeAsync(string couponCode);
       
    }
}
