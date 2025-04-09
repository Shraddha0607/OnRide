using Microsoft.AspNetCore.Authorization;

namespace OnRideApp.Controllers;

[Route("/api/[controller]")]
[ApiController]
[Authorize]
public class TrackingController : ControllerBase
{
    private readonly ITrackingService trackingService;
    private readonly ILogger<TrackingController> logger;

    public TrackingController(ITrackingService trackingService,
        ILogger<TrackingController> logger)
    {
        this.trackingService = trackingService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> UpdateLocation(LocationRequest locationRequest)
    {
        try
        {
            var location = await trackingService.AddLocationAsync(locationRequest.CabId, locationRequest.Latitude, locationRequest.Longitude);
            return Ok("Location updated.");
        }
        catch (Exception ex)
        {
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
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
        catch (Exception ex)
        {
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest();
        }
    }
}