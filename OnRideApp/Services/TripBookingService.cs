using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos;
using OnRideApp.Repositories;
using OnRideApp.Transformer;

namespace OnRideApp.Services
{
    public class TripBookingService : ITripBookingService
    {
        private readonly ITripBookingRepository tripBookingRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICabRepository cabRepository;

        public TripBookingService(
            ITripBookingRepository tripBookingRepository,
            ICustomerRepository customerRepository,
            ICabRepository cabRepository)
        {
            this.tripBookingRepository = tripBookingRepository;
            this.customerRepository = customerRepository;
            this.cabRepository = cabRepository;
        }


        public async Task<TripBooking> AddTripBookingAsync(TripBookingRequest tripBookingRequest)
        {
            List<Customer> allCustomers =  customerRepository.GetAllAsync();

            try
            {
                Customer customer = allCustomers.FirstOrDefault(x => x.EmailId == tripBookingRequest.CustomerEmailId);
                
                TripBooking tripBooking = TripBookingTransformer.TripRequestToTripBooking(tripBookingRequest);

                Cab cab = cabRepository.getRandomAvailableCab();

                tripBooking.TotalFare = tripBookingRequest.TripDistancePrKm * cab.FarePrKm;


                var trip = await tripBookingRepository.AddAsync(tripBooking);
                return tripBooking;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
            
        }
    }
}
