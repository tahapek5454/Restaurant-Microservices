using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Services.ProductAPI.Models;

namespace Restaurant.Services.ProductAPI.Data.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(GetSeedDatas());
        }

        private IEnumerable<Product> GetSeedDatas()
        {
            yield return new Product()
            {
                Id = 1,
                Name_EN = "Samosa",
                Name_TR = "Samosa",
                Price = 15,
                Descripton_EN = "Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.",
                Description_TR = "Samosa, Hint mutfağına ait geleneksel bir atıştırmalık veya çeşitli yemeklerde bir yan lezzet olarak sıkça bulunan bir hamur işidir. ",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName_EN = "Appetizer",
                CategoryName_TR = "Aperatif",
                CreatedDate = new DateTime(2024, 1, 25),
                UpdatedDate = new DateTime(2024, 1, 25),
            };

            yield return new Product()
            {
                Id = 2,
                Name_EN = "Rice",
                Name_TR = "Pilav",
                Price = 14.50,
                Descripton_EN = " Rice is a fundamental cereal grain widely consumed worldwide.<br/> It serves as a staple ingredient in various dishes and is used as a primary component in many cultures for main meals or as a side dish. ",
                Description_TR = "Pirinç, dünya genelinde yaygın olarak tüketilen temel bir tahıl ürünüdür.<br/> Pirinç, çeşitli yemeklerin temel malzemelerinden biridir ve birçok kültürde ana öğünlerde veya yan yemek olarak kullanılır.",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName_EN = "Side dish",
                CategoryName_TR = "Yan yemek",
                CreatedDate = new DateTime(2024, 1, 25),
                UpdatedDate = new DateTime(2024, 1, 25),
            };

            yield return new Product()
            {
                Id = 3,
                Name_EN = "Citrus Glazed Chicken with Roasted Vegetables",
                Name_TR = "Narenciye Soslu Tavuk ve Fırınlanmış Sebzeler",
                Price = 14.50,
                Descripton_EN = "In this recipe, chicken thighs are marinated with a glaze made from fresh citrus juice and then baked in the oven.<br/> Once the chicken is cooked to tender and juicy perfection, it is served with a side of roasted vegetables.<br/> This dish brings together the bright and refreshing flavors while offering a healthy and satisfying main course.",
                Description_TR = "Bu tarifte, tavuk butları, taze narenciye suyu bazlı bir sosta marine edilip fırında pişirilir. <br/> Tavuklar, yumuşak ve sulu olana kadar pişirildikten sonra yanında fırınlanmış sebzelerle servis edilir. <br/> Bu tarif, taze ve ferah lezzetleri bir araya getirirken sağlıklı ve doyurucu bir ana yemek sunar.",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName_EN = "Main dish",
                CategoryName_TR = "Ana yemek",
                CreatedDate = new DateTime(2024, 1, 25),
                UpdatedDate = new DateTime(2024, 1, 25),
            };
        }
    }
}
