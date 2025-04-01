using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> AddAsync(Coupon coupon);
    }
}
