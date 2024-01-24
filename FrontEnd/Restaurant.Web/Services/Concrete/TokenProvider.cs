using Newtonsoft.Json.Linq;
using Restaurant.Integration.Domain.Consts;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Services.Concrete
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken()
        {
            _contextAccessor?.HttpContext?.Response.Cookies.Delete(ConstData.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;
            
            var hasToken = _contextAccessor?.HttpContext?.Request.Cookies.TryGetValue(ConstData.TokenCookie, out token);

            return hasToken.HasValue ? token : null;
        }

        public void SetToken(string token)
        {
            _contextAccessor?.HttpContext?.Response.Cookies.Append(ConstData.TokenCookie, token);
        }
    }
}
