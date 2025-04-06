namespace OnRideApp.Services;

public interface ICouponService
{
    Task<Coupon> AddCouponAsync(CouponRequest couponRequest);
}