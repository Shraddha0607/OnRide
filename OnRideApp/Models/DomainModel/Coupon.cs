namespace OnRideApp.Models.DomainModel
{
    public class Coupon
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public int percentageDiscount { get; set; }
    }
}
