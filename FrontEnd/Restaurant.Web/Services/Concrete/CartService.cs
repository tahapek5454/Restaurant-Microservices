using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Cart;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Services.Concrete
{
    public class CartService :BaseService, ICartService
    {
        public CartService(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
        }

        public async Task<ResponseDto<BlankDto>> ApplyCouponAsync(CartDto cartDto)
         => await SendAsync<CartDto, BlankDto>(new()
         {
             ActionType = Integration.Domain.Enums.ActionType.POST,
             Data = cartDto,
             Language = Integration.Domain.Enums.SystemLanguage.en_EN,
             AccessToken = null,
             Url = $"{ConstData.ShoppingCartApıBase}/Carts/ApplyCoupon"

         });

        public async Task<ResponseDto<CartDto>> GetCartByUserIdAsync(int userId)
        => await SendAsync<BlankDto, CartDto>(new()
        {
            ActionType = Integration.Domain.Enums.ActionType.GET,
            Language = Integration.Domain.Enums.SystemLanguage.en_EN,
            Url = $"{ConstData.ShoppingCartApıBase}/Carts/{userId}",
            AccessToken = null,
            Data = null,
        });

        public async Task<ResponseDto<BlankDto>> RemoveCartAsync(int cartDetailId)
            => await SendAsync<int, BlankDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.DELETE,
                Language = Integration.Domain.Enums.SystemLanguage.en_EN,
                AccessToken=null,
                Data = cartDetailId,
                Url = $"{ConstData.ShoppingCartApıBase}/Carts"
            });


        public async Task<ResponseDto<BlankDto>> RemoveCoupon(CartDto cartDto)
            => await SendAsync<CartDto, BlankDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.POST,
                Language = Integration.Domain.Enums.SystemLanguage.en_EN,
                Data = cartDto,
                Url = $"{ConstData.ShoppingCartApıBase}/Carts/RemoveCoupon"
            });

        public async Task<ResponseDto<CartDto>> UpsertCartAsync(CartDto cartDto)
            => await SendAsync<CartDto, CartDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.POST,
                Language = Integration.Domain.Enums.SystemLanguage.en_EN,
                Data = cartDto,
                AccessToken = null,
                Url = $"{ConstData.ShoppingCartApıBase}/Carts"
            });
    }

}
