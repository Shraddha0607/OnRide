namespace OnRideApp.Models.Dtos.Request;

public class CouponRequest
{
    [Required]
    [RegularExpression(RegexPatterns.CouponCode, ErrorMessage ="Please give alphnumeric characters only!")]
    [StringLength(10, ErrorMessage = "Coupon code must be upto 10 characters!")]
    public string CouponCode { get; set; }

    [Required]
    [Range(1, 30, ErrorMessage = "Discount should be between 1 to 30")]
    public int percentageDiscount { get; set; }
}
