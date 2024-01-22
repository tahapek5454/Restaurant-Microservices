using Restaurant.Integration.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Services.CouponAPI.Models
{
    public class Coupon: BaseEntity
    {
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }

        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
