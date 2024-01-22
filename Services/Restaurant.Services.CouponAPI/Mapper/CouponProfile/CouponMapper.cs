using AutoMapper;
using Restaurant.Services.CouponAPI.Dtos;
using Restaurant.Services.CouponAPI.Models;

namespace Restaurant.Services.CouponAPI.Mapper.CouponProfile
{
    public class CouponMapper : Profile
    {
        public CouponMapper()
        {
            CreateMap<Coupon, CouponDto>()
                .ReverseMap();

            CreateMap<CouponCreateDto, Coupon>();

            CreateMap<CouponUpdateDto, Coupon>();
        }
    }
}
