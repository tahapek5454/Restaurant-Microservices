namespace Restaurant.Web.Models.Dtos.Coupon
{
    public class CouponUpdateDto
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
