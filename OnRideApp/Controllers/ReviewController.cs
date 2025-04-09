using Microsoft.AspNetCore.Authorization;

namespace OnRideApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        private readonly ILogger logger;

        public ReviewController(IReviewService reviewService,
            ILogger<ReviewController> logger)
        {
            this.reviewService = reviewService;
            this.logger = logger;
        }

        [HttpPost("tripId/{tripId}")]
        public async Task<IActionResult> AddReview([FromRoute] int tripId, [FromBody] ReviewRequest reviewRequest)
        {
            try
            {
                var review = await reviewService.SubmitReview(tripId, reviewRequest);
                return Ok(review);
            }
            catch (Exception ex)
            {
                logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
                logger.LogError(ex.Message);
                if (ex is CustomException)
                {
                    return BadRequest(ex.Message);
                }
                return BadRequest("Error occured while adding review!");
            }
        }
    }
}