using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.DomainModel;
using OnRideApp.Services;

namespace OnRideApp.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class TrackingController : ControllerBase
{
    private readonly ITrackingService trackingService;
    private readonly ILogger logger;

    public TrackingController(ITrackingService trackingService,
        ILogger logger)
    {
        this.trackingService = trackingService;
        this.logger = logger;
    }

    [HttpPost("{cabId}")]
    public async Task<IActionResult> UpdateLocation(
        [FromRoute] int cabId,
        [FromQuery] double latitude,
        [FromQuery] double longitude)
    {
        try
        {
            var location = await trackingService.AddLocationAsync(cabId, latitude, longitude);
            return Ok("Location updated.");
        }
        catch(Exception ex)
        {
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest("Error occurred while adding location!");
        }
        
    }

    [HttpGet("/tripId/{tripId}")]
    public async Task<IActionResult> trackCabAsync([FromRoute] int tripId)
    {
        try
        {
            var location = await trackingService.trackCabAsync(tripId);
            return Ok(location);
        }
        catch(Exception ex)
        {
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest();
        }
        
    }
}
