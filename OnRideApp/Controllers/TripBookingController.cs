using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.Dtos;
using OnRideApp.Services;

namespace OnRideApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripBookingController
    {
        private readonly ITripBookingService tripBookingService;

        public TripBookingController(ITripBookingService tripBookingService)
        {
            this.tripBookingService = tripBookingService;
        }

        [HttpPost]
        public async Task<string> bookCab(TripBookingRequest tripBookingRequest)
        {
            await tripBookingService.AddTripBookingAsync(tripBookingRequest);
            return "Trip added successfully";
        }
    }
}
