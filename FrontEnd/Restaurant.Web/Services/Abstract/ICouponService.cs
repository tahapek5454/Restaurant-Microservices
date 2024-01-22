using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Coupon;

namespace Restaurant.Web.Services.Abstract
{
    public interface ICouponService: IBaseService
    {
        Task<ResponseDto<CouponDto>> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDto<CouponDto>> GetCouponByIdAsync(int id);
        Task<ResponseDto<List<CouponDto>>> GetAllCouponAsync();
        Task<ResponseDto<BlankDto>> CreateCouponAsync(CouponCreateDto couponCreateDto);
        Task<ResponseDto<BlankDto>> UpdateCouponAsync(CouponUpdateDto coupononUpdateDto);
        Task<ResponseDto<BlankDto>> DeleteCouponAsync(int id);  
    }
}
