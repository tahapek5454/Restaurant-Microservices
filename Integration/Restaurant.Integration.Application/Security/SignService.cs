using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Restaurant.Integration.Application.Security
{
    public static class SignService
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
          => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
