namespace Restaurant.Services.CouponAPI.Dtos
{
    public class CouponCreateDto
    {
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
