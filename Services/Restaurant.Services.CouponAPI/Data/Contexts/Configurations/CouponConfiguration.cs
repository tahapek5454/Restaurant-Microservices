using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Services.CouponAPI.Models;

namespace Restaurant.Services.CouponAPI.Data.Contexts.Configurations
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            // any conf about entity
            builder.HasData(GetSeedDatas());
        }

        private ICollection<Coupon> GetSeedDatas()
        {
            return new List<Coupon>()
            {
                new Coupon 
                { 
                    Id = 1, 
                    CouponCode="10OFF", 
                    DiscountAmount=10, 
                    MinAmount = 20, 
                    CreatedDate = new DateTime(2024, 1, 1)
                },
                new Coupon
                {
                    Id = 2, 
                    CouponCode="20OFF",
                    DiscountAmount=20,
                    MinAmount = 40,
                    CreatedDate = new DateTime(2024, 1, 1)
                }
            };
        }
    }
}
