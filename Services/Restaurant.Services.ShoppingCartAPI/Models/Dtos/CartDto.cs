namespace Restaurant.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public ICollection<CartDetailDto> CartDetails { get; set; }
    }
}
