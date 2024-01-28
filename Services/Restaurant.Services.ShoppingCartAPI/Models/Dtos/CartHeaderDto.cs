using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restaurant.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? CouponCode { get; set; }
        [JsonIgnore]
        public double Discount { get; set; }
        [JsonIgnore]

        public double CartTotal { get; set; }
    }
}
