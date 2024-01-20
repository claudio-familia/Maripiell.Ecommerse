using Maripiell.Common.Common.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Maripiell.Services.CouponAPI.Domain.Models
{
    public class Coupon: BaseEntity
    {
        public Coupon(string code, double discountAmount, int minAmount)
        {
            this.Code = code;
            this.DiscountAmount = discountAmount;
            this.MinAmount = minAmount;
            this.CreatedBy = 1;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = 1;
        }

        public Coupon()
        {
            this.CreatedBy = 1;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
            this.UpdatedBy = 1;
        }

        [Required]
        public string Code { get; set; }
        
        [Required]
        public double DiscountAmount { get; set; }
        
        [Required]
        public int MinAmount { get; set; }
    }
}
