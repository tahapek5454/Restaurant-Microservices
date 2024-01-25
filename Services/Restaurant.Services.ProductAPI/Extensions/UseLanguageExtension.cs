using Restaurant.Services.ProductAPI.Middlewares;

namespace Restaurant.Services.ProductAPI.Extensions
{
    public static class UseLanguageExtension
    {
        public static IApplicationBuilder UseLanguage(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LanguageMiddleware>();
        }
    }
}
