using AutoMapper;
using Restaurant.Services.ShoppingCartAPI.Models;
using Restaurant.Services.ShoppingCartAPI.Models.Dtos;

namespace Restaurant.Services.ShoppingCartAPI.Mapper.CartProfile
{
    public class CartMapper: Profile
    {
        public CartMapper()
        {
            CreateMap<CartDetailDto, CartDetail>()
                .ForMember(dest => dest.CartHeader, opt => opt.MapFrom(src => src.CartHeader));
            CreateMap<CartHeaderDto, CartHeader>();
        }
    }
}
