using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Auths;
using Restaurant.Web.Services.Abstract;
using System.Data;

namespace Restaurant.Web.Services.Concrete
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
        }

        public async Task<ResponseDto<BlankDto>> AssignRoleToUserAsync(List<string> roles, int userid)
            => await SendAsync<List<string>, BlankDto>(new()
            {
                Url = $"{ConstData.AuthAPIBase}/Auth/AssignRoleToUser/{userid}",
                ActionType = Integration.Domain.Enums.ActionType.POST,
                Data = roles,
                AccessToken = null
            }, false);

        public async Task<ResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
            => await SendAsync<LoginRequestDto, LoginResponseDto>(new()
            {
                Url = $"{ConstData.AuthAPIBase}/Auth/Login",
                ActionType = Integration.Domain.Enums.ActionType.POST,
                Data = loginRequestDto,
                AccessToken = null
            }, false);

        public async Task<ResponseDto<BlankDto>> RegisterAsync(RegistrationRequestDto registrationRequestDto)
            => await SendAsync<RegistrationRequestDto, BlankDto>(new()
            {
                Url = $"{ConstData.AuthAPIBase}/Auth/Register",
                ActionType = Integration.Domain.Enums.ActionType.POST,
                Data = registrationRequestDto,
                AccessToken = null
            }, false);
    }
}
