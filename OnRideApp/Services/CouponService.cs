namespace OnRideApp.Services;

public class CouponService : ICouponService
{
    private readonly RideDbContext rideDbContext;

    public CouponService(RideDbContext rideDbContext)
    {
        this.rideDbContext = rideDbContext;
    }

    public async Task<Coupon> AddCouponAsync(CouponRequest couponRequest)
    {
        var couponExist = await rideDbContext.Coupons
            .AsNoTracking()
            .AnyAsync(x => x.CouponCode == couponRequest.CouponCode);

        if (couponExist)
        {
            throw new CustomException("Coupon code must be unique!");
        }

        Coupon newCoupon = new()
        {
            CouponCode = couponRequest.CouponCode,
            percentageDiscount = couponRequest.percentageDiscount
        };

        await rideDbContext.Coupons.AddAsync(newCoupon);
        await rideDbContext.SaveChangesAsync();
        return newCoupon;
    }
}