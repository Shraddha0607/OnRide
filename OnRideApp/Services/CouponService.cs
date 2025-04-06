namespace OnRideApp.Services;

public class CouponService : ICouponService
{
    private readonly RideDbContext rideDbContext;

    public CouponService(RideDbContext rideDbContext)
    {
        this.rideDbContext = rideDbContext;
    }

    public async Task<Coupon> AddCouponAsync(string coupon, int discount)
    {
        var couponExist = await rideDbContext.Coupons.AsNoTracking().AnyAsync(x => x.CouponCode == coupon);
        if (couponExist)
        {
            throw new CustomException("Coupon code must be unique!");
        }

        Coupon newCoupon = new()
        {
            CouponCode = coupon,
            percentageDiscount = discount
        };

        await rideDbContext.Coupons.AddAsync(newCoupon);
        await rideDbContext.SaveChangesAsync();
        return newCoupon;
    }
}