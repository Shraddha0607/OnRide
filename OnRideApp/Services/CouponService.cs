using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Services
{
    public class CouponService : ICouponService
    {
        private readonly RideDbContext rideDbContext;

        public CouponService(RideDbContext rideDbContext) 
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<Coupon> AddCouponAsync(string coupon, int discount)
        {
            Coupon newCoupon = new Coupon
            {
                CouponCode = coupon,
                percentageDiscount = discount
            };

            await rideDbContext.Coupons.AddAsync(newCoupon);
            await rideDbContext.SaveChangesAsync();
            return newCoupon; ;
        }
    }
}
