using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Services.ShoppingCartAPI.Models
{
    public class CartHeader
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? CouponCode { get; set; }
        [NotMapped]
        public double Discount { get; set; }
        [NotMapped]
        public double CartTotal { get; set; }

    }
}
