using Restaurant.Services.AuthAPI.Models;
using Restaurant.Services.AuthAPI.Models.Dtos;

namespace Restaurant.Services.AuthAPI.Services.Abstract
{
    public interface ITokenService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);
    }
}
