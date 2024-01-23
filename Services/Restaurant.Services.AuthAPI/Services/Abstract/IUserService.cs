using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.AuthAPI.Models.Dtos;

namespace Restaurant.Services.AuthAPI.Services.Abstract
{
    public interface IUserService
    {
        Task<ResponseDto<BlankDto>> RegisterUserAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto<LoginResponseDto>> LoginUserAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto<BlankDto>> AssignRoleToUserAsync(int userId, List<string> roles);
    }
}
