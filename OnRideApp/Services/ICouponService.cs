using OnRideApp.Models.DomainModel;

namespace OnRideApp.Services;

public interface ICouponService
{
    Task<Coupon> AddCouponAsync(string coupon, int discount);
}
