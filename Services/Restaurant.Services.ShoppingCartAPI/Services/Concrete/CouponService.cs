using Newtonsoft.Json;
using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.ShoppingCartAPI.Models.Dtos;
using Restaurant.Services.ShoppingCartAPI.Services.Abstract;

namespace Restaurant.Services.ShoppingCartAPI.Services.Concrete
{
    public class CouponService : BaseService, ICouponService
    {
        IHttpContextAccessor _httpContextAccessor;
        public CouponService(IHttpClientFactory _httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(_httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CouponDto> GetCouponByCodeAsync(string couponCode)
        {
            var token = GetRequestToken();

            var response = await SendAsync<BlankDto, CouponDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.GET,
                Url = $"{ConstData.CouponAPIBase}/Coupons/GetCouponByCode?couponCode={couponCode}",
                Language = Integration.Domain.Enums.SystemLanguage.en_EN,
                AccessToken = token
            });

            return response?.Data ?? new CouponDto();
        }

        private string GetRequestToken()
        {
            var requestHeaders = _httpContextAccessor?.HttpContext?.Request.Headers;
            string? authorizeValue = requestHeaders?.Authorization;

            if(authorizeValue is null)
                return "";

            const string bearerPrefix = "Bearer ";

            if (authorizeValue.StartsWith(bearerPrefix))
                return authorizeValue.Substring(bearerPrefix.Length);

            return "";
        }
    }
}
