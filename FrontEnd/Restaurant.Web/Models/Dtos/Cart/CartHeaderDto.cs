namespace Restaurant.Web.Models.Dtos.Cart
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }

        public double CartTotal { get; set; }
    }
}
