
using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Coupon;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Services.Concrete
{
    public class CouponService : BaseService, ICouponService
    {
        public CouponService(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
        }

        public async Task<ResponseDto<BlankDto>> CreateCouponAsync(CouponCreateDto couponCreateDto)
             => await SendAsync<CouponCreateDto, BlankDto>(new()
             {
                 Url = $"{ConstData.CouponAPIBase}/Coupons",
                 ActionType = Integration.Domain.Enums.ActionType.POST,
                 Data = couponCreateDto,
                 AccessToken = null
             });

        public async Task<ResponseDto<BlankDto>> DeleteCouponAsync(int id)
            => await SendAsync<BlankDto, BlankDto>(new()
            {
                Url = $"{ConstData.CouponAPIBase}/Coupons/{id}",
                ActionType = Integration.Domain.Enums.ActionType.DELETE,
                Data = null,
                AccessToken = null
            });


        public async Task<ResponseDto<List<CouponDto>>> GetAllCouponAsync()
            => await SendAsync<BlankDto, List<CouponDto>>(new()
            {
                Url = $"{ConstData.CouponAPIBase}/Coupons/GetAllCoupon",
                ActionType = Integration.Domain.Enums.ActionType.GET,
                Data = null,
                AccessToken = null
            });


        public async Task<ResponseDto<CouponDto>> GetCouponByCodeAsync(string couponCode)
            => await SendAsync<BlankDto, CouponDto>(new()
            {
                Url = $"{ConstData.CouponAPIBase}/Coupons/GetCouponByCode?couponCode={couponCode}",
                ActionType = Integration.Domain.Enums.ActionType.GET,
                Data = null,
                AccessToken= null
            });
      

        public async Task<ResponseDto<CouponDto>> GetCouponByIdAsync(int id)
            => await SendAsync<BlankDto, CouponDto>(new()
            {
                Url = $"{ConstData.CouponAPIBase}/Coupons/GetCouponById/{id}",
                ActionType = Integration.Domain.Enums.ActionType.GET,
                Data = null,
                AccessToken = null
            });

        public async Task<ResponseDto<BlankDto>> UpdateCouponAsync(CouponUpdateDto coupononUpdateDto)
            => await SendAsync<CouponUpdateDto, BlankDto>(new()
            {
                Url = $"{ConstData.CouponAPIBase}/Coupons",
                ActionType = Integration.Domain.Enums.ActionType.PUT,
                Data = coupononUpdateDto,
                AccessToken = null
            });
       
    }
}
