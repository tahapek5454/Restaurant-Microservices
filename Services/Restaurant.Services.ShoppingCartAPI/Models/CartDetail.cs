using Restaurant.Services.ShoppingCartAPI.Models.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Services.ShoppingCartAPI.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
