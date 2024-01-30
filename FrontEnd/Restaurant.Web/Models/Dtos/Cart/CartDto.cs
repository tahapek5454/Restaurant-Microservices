namespace Restaurant.Web.Models.Dtos.Cart
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public ICollection<CartDetailDto> CartDetails { get; set; }
    }
}
