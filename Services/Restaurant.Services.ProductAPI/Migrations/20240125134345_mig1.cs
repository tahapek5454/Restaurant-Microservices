using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripton_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryName_TR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName_EN", "CategoryName_TR", "CreatedDate", "Description_TR", "Descripton_EN", "ImageUrl", "Name_EN", "Name_TR", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Aperatif", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samosa, Hint mutfağına ait geleneksel bir atıştırmalık veya çeşitli yemeklerde bir yan lezzet olarak sıkça bulunan bir hamur işidir. ", "Quisque vel lacus ac magna, vehicula sagittis ut non lacus.<br/> Vestibulum arcu turpis, maximus malesuada neque. Phasellus commodo cursus pretium.", "https://placehold.co/603x403", "Samosa", "Samosa", 15.0, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Side dish", "Yan yemek", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pirinç, dünya genelinde yaygın olarak tüketilen temel bir tahıl ürünüdür.<br/> Pirinç, çeşitli yemeklerin temel malzemelerinden biridir ve birçok kültürde ana öğünlerde veya yan yemek olarak kullanılır.", " Rice is a fundamental cereal grain widely consumed worldwide.<br/> It serves as a staple ingredient in various dishes and is used as a primary component in many cultures for main meals or as a side dish. ", "https://placehold.co/603x403", "Rice", "Pilav", 14.5, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Main dish", "Ana yemek", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bu tarifte, tavuk butları, taze narenciye suyu bazlı bir sosta marine edilip fırında pişirilir. <br/> Tavuklar, yumuşak ve sulu olana kadar pişirildikten sonra yanında fırınlanmış sebzelerle servis edilir. <br/> Bu tarif, taze ve ferah lezzetleri bir araya getirirken sağlıklı ve doyurucu bir ana yemek sunar.", "In this recipe, chicken thighs are marinated with a glaze made from fresh citrus juice and then baked in the oven.<br/> Once the chicken is cooked to tender and juicy perfection, it is served with a side of roasted vegetables.<br/> This dish brings together the bright and refreshing flavors while offering a healthy and satisfying main course.", "https://placehold.co/603x403", "Citrus Glazed Chicken with Roasted Vegetables", "Narenciye Soslu Tavuk ve Fırınlanmış Sebzeler", 14.5, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
