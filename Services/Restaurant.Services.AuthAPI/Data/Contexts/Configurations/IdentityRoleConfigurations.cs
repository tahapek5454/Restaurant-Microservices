using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurant.Services.AuthAPI.Data.Contexts.Configurations
{
    public class IdentityRoleConfigurations : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(SeedData());
        }
        private List<IdentityRole<int>> SeedData()
        {
            return new()
            {
                new IdentityRole<int>()
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "000ac991-b4f7-4785-9a48-b46e3a600001"
                },
                new IdentityRole<int>()
                {
                    Id = 2,
                    Name = "customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = "000ac992-b4f7-4785-9a48-b46e3a600001"
                },
            };
        }
    }
}

