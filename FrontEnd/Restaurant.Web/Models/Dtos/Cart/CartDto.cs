namespace Restaurant.Web.Models.Dtos.Cart
{
    public class CartDto
    {
        public CartDto()
        {
            CartDetails = new List<CartDetailDto>();
        }
        public CartHeaderDto CartHeader { get; set; }
        public ICollection<CartDetailDto> CartDetails { get; set; }
    }
}
