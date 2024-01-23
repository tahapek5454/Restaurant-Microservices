using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Services.AuthAPI.Data.Contexts;

namespace Restaurant.Services.AuthAPI
{
    public static class ServiceRegistration
    {
        public static void AddAuthServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            serviceCollection.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
