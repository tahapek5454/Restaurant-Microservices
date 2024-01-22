using Microsoft.EntityFrameworkCore;
using Restaurant.Services.CouponAPI.Data.Contexts;

namespace Restaurant.Services.CouponAPI
{
    public static class ServiceRegistration
    {
        public static void AddCouponServices(this IServiceCollection serviceCollection, string connecitonString)
        {
            serviceCollection.AddDbContext<AppDbContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(connecitonString);
            });
        }
    }
}
