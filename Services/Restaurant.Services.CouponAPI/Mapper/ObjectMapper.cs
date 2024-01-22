using AutoMapper;

namespace Restaurant.Services.CouponAPI.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

            });

            return config.CreateMapper();
        });

        public static IMapper Mapper { get { return lazy.Value; } }
    }
}
