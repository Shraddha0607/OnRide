using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly RideDbContext rideDbContext;

        public CouponRepository(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<Coupon> AddAsync(Coupon coupon)
        {
             await rideDbContext.AddAsync(coupon);
              await rideDbContext.SaveChangesAsync();
            return coupon;
        }
    }
}
