using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartDetailDto
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto? CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
    }
}
