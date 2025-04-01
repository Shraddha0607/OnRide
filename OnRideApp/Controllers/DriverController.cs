using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.Dtos;
using OnRideApp.Services;

namespace OnRideApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }

        [HttpPost]
        public async Task<string> addDriver(DriverRequest driverRequest)
        {
            await driverService.AddDriverAsync(driverRequest);
            return "driver added";
        }
            
    }
    
}
