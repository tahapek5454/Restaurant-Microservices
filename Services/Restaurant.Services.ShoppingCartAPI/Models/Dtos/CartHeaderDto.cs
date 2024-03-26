

namespace Restaurant.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }

        public double CartTotal { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
