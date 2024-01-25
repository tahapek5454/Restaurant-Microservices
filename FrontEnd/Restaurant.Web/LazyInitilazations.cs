using Restaurant.Web.Services.Abstract;
using Restaurant.Web.Services.Concrete;

namespace Restaurant.Web
{
    public static class LazyInitilazations
    {
        public static IHttpContextAccessor _accessor { get; private set; }

        public static void InitializeHttpContextAccessor(IServiceProvider serviceProvider)
        {
            _accessor = serviceProvider.GetService<IHttpContextAccessor>();
        }

        private static readonly Lazy<ITokenProvider> lazyTokenProvider = new Lazy<ITokenProvider>(() =>
        {
            return new TokenProvider(_accessor);
        });

        public static ITokenProvider TokenProvider { get { return lazyTokenProvider.Value; } }

      
    }
}
