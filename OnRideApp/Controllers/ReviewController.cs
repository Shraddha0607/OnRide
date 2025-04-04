﻿using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Services;

namespace OnRideApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;
        private readonly ILogger logger;
        public ReviewController(IReviewService reviewService,
            ILogger logger)
        {
            this.reviewService = reviewService;
            this.logger = logger;
        }

        [HttpPost("tripId/{tripId}")]
        public async Task<IActionResult> AddReview([FromRoute] int tripId,[FromBody] ReviewRequest reviewRequest)
        {
            try
            {
                var review =  await reviewService.SubmitReview(tripId, reviewRequest);
                return Ok(review);
            }
            catch(Exception ex)
            {
                logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
                logger.LogError(ex.Message);

                return BadRequest("Error occured while adding review!");
            }
            
        }
    }
}
