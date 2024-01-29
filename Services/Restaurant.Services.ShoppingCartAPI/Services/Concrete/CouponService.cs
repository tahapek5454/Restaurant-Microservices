using Newtonsoft.Json;
using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.ShoppingCartAPI.Models.Dtos;
using Restaurant.Services.ShoppingCartAPI.Services.Abstract;

namespace Restaurant.Services.ShoppingCartAPI.Services.Concrete
{
    public class CouponService(IHttpClientFactory _httpClientFactory) : ICouponService
    {
        public async Task<CouponDto> GetCouponByCodeAsync(string couponCode)
        {
            var client =  _httpClientFactory.CreateClient("Coupon");
            var httpResponse = await client.GetAsync($"{ConstData.CouponAPIBase}/Coupons/GetCouponByCode?couponCode={couponCode}");
            var response = JsonConvert.DeserializeObject<ResponseDto<CouponDto>>(await httpResponse.Content.ReadAsStringAsync());

            return response?.Data ?? new CouponDto();
        }
    }
}
