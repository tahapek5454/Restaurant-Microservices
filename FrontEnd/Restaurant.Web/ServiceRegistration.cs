using Restaurant.Web.Services.Abstract;
using Restaurant.Web.Services.Concrete;

namespace Restaurant.Web
{
    public static class ServiceRegistration
    {
        public static void AddWebServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICouponService, CouponService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<ITokenProvider, TokenProvider>();
        }
    }
}
