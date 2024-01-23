using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Integration.Application.Security;
using Restaurant.Services.AuthAPI.Models;
using Restaurant.Services.AuthAPI.Models.Dtos;
using Restaurant.Services.AuthAPI.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant.Services.AuthAPI.Services.Concrete
{
    public class TokenService : ITokenService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly CustomTokenOptions _customTokenOptions;
        public TokenService(UserManager<AppUser> userManager, IOptions<CustomTokenOptions> options)
        {
            _userManager = userManager;
            _customTokenOptions = options.Value;
        }

        public async Task<LoginResponseDto> CreateTokenAsync(AppUser user)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_customTokenOptions.AccessTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_customTokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (issuer: _customTokenOptions.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: await GetClaims(user, _customTokenOptions.Audiences));

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var loginResponseDto = new LoginResponseDto
            {
                AccessToken = token
            }; 

            return loginResponseDto;
        }


        private async Task<IEnumerable<Claim>> GetClaims(AppUser user, string audiences)
        {
            var listedAudiences = audiences.Split(",");

            var userClaimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim("name", user.Name),
                new Claim("surname", user.Surname),
                new Claim("phonenumber", user.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            userClaimList.AddRange(listedAudiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            var userRoles = await _userManager.GetRolesAsync(user);
            userClaimList.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));

            return userClaimList;
        }
    }
}
