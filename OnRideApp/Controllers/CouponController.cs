namespace OnRideApp.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
    private readonly ICouponService couponService;
    private readonly ILogger logger;

    public CouponController(ICouponService couponService,
        ILogger<CouponController> logger)
    {
        this.couponService = couponService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CouponRequest couponRequest)
    {
        try
        {
            var newCoupon = await couponService.AddCouponAsync(couponRequest);
            return Ok("Coupon added successfully");
        }
        catch (Exception ex)
        {
            logger.LogError("{} Error :  {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);

            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest("Error occured while adding coupon.");
        }
    }
}