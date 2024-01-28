using AutoMapper;
using Restaurant.Services.ShoppingCartAPI.Mapper.CartProfile;

namespace Restaurant.Services.ShoppingCartAPI.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.AddProfile<CartMapper>();

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
