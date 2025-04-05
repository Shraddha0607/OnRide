using System.ComponentModel.DataAnnotations;

namespace OnRideApp.Models.DomainModel;

public class Coupon
{
    public int Id { get; set; }
    [StringLength(10, ErrorMessage ="Coupon code must be upto 10 characters!")]
    public string CouponCode { get; set; }
    [Range(1, 30, ErrorMessage ="Discount should be between 1 to 30")]
    public int percentageDiscount { get; set; }
}
