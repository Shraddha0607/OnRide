using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Repositories;
using OnRideApp.Services;

namespace OnRideApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpPost("tripId/{tripId}")]
        public async Task<string> AddReview([FromRoute] int tripId,[FromBody] ReviewRequest reviewRequest)
        {
            return await reviewService.SubmitReview(tripId, reviewRequest);
        }
    }
}
