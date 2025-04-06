namespace OnRideApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripBookingController : ControllerBase
{
    private readonly ITripBookingService tripBookingService;
    private readonly ILogger logger;

    public TripBookingController(ITripBookingService tripBookingService,
        ILogger<TripBookingController> logger)
    {
        this.tripBookingService = tripBookingService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> bookCab(TripBookingRequest tripBookingRequest)
    {
        try
        {
            await tripBookingService.AddTripBookingAsync(tripBookingRequest);
            return Ok("Trip added successfully");
        }
        catch (Exception ex)
        {
            {
                logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
                logger.LogError(ex.StackTrace);
                return BadRequest("Error occured while booking cab!");
            }
        }
    }
}