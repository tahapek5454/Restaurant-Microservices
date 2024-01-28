using Microsoft.EntityFrameworkCore;
using Restaurant.Services.ShoppingCartAPI.Models;

namespace Restaurant.Services.ShoppingCartAPI.Data.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }


   

    }
}
