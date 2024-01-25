using AutoMapper;
using Restaurant.Services.ProductAPI.Extensions;
using Restaurant.Services.ProductAPI.Models;
using Restaurant.Services.ProductAPI.Models.Dtos;

namespace Restaurant.Services.ProductAPI.Mapper.ProductProfile
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.Descripton, opt => opt.MapFromLanguage(opt.DestinationMember));
        }
    }
}
