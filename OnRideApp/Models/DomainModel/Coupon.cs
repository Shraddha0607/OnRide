namespace OnRideApp.Models.DomainModel;

public class Coupon
{
    public int Id { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "Coupon code must be upto 10 characters!")]
    public string CouponCode { get; set; }

    [Required]
    [Range(1, 30, ErrorMessage = "Discount should be between 1 to 30")]
    public int percentageDiscount { get; set; }
}