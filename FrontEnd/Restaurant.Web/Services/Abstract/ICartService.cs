using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Cart;

namespace Restaurant.Web.Services.Abstract
{
    public interface ICartService: IBaseService
    {
        Task<ResponseDto<CartDto>> GetCartByUserIdAsync(int userId);
        Task<ResponseDto<CartDto>> UpsertCartAsync(CartDto cartDto);

        Task<ResponseDto<BlankDto>> RemoveCartAsync(int cartDetailId);

        Task<ResponseDto<BlankDto>> ApplyCouponAsync(CartDto cartDto);
        Task<ResponseDto<BlankDto>> RemoveCoupon(CartDto cartDto);

        Task<ResponseDto<BlankDto>> EmailCart(CartDto cartDto);

    }
}
