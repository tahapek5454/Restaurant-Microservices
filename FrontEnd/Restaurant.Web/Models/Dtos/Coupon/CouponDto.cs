namespace Restaurant.Web.Models.Dtos.Coupon
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
