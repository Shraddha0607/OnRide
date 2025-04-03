using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Services;

namespace OnRideApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly IDriverService driverService;
    private readonly ILogger logger;

    public DriverController(IDriverService driverService,
        ILogger logger)
    {
        this.driverService = driverService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddDriver(DriverRequest driverRequest)
    {
        try
        {
            await driverService.AddDriverAsync(driverRequest);
            return Ok("driver added");
        }
        catch (Exception ex)
        {
            logger.LogError("{} Error :  {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest("Error occured while adding driver");
        }
        
    }
        
}

