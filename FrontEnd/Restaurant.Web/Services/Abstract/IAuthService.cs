using Microsoft.AspNetCore.Mvc;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Auths;

namespace Restaurant.Web.Services.Abstract
{
    public interface IAuthService: IBaseService
    {
        Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto<BlankDto>> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto<BlankDto>> AssignRoleToUserAsync(List<string> roles, int userid);
    }
}
