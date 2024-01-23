using AutoMapper;
using Restaurant.Services.AuthAPI.Models;
using Restaurant.Services.AuthAPI.Models.Dtos;

namespace Restaurant.Services.AuthAPI.Mapper.AppUserProfile
{
    public class AppUserMapper: Profile
    {
        public AppUserMapper()
        {
            CreateMap<RegistrationRequestDto, AppUser>();
        }
    }
}
