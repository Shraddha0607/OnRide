using OnRideApp.Models.DomainModel;
using OnRideApp.Repositories;

namespace OnRideApp.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository couponRepository;

        public CouponService(ICouponRepository couponRepository) 
        {
            this.couponRepository = couponRepository;
        }

        public async Task<Coupon> AddCouponAsync(string coupon, int discount)
        {
            Coupon newCoupon = new Coupon
            {
                CouponCode = coupon,
                percentageDiscount = discount
            };

            return await couponRepository.AddAsync(newCoupon);
        }
    }
}
