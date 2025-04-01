using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.DomainModel;
using OnRideApp.Services;

namespace OnRideApp.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService couponService;

        public CouponController(ICouponService couponService)
        {
            this.couponService = couponService;
        }

        [HttpPost]
        public async Task<string> CreateCoupon(
            [FromQuery] string coupon,
            [FromQuery] int discount)
        {
            var newCoupon = await couponService.AddCouponAsync(coupon, discount);
            if (newCoupon == null)
            {
                // handle error
            }
            return "Coupon added successfully";
        }
    }
}
