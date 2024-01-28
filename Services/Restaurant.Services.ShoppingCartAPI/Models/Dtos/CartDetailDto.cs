using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restaurant.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartDetailDto
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        [JsonIgnore]
        public CartHeaderDto? CartHeader { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
    }
}
