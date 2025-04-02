using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Repositories;
using OnRideApp.Transformer;

namespace OnRideApp.Services
{
    public class TripBookingService : ITripBookingService
    {
        private readonly ITripBookingRepository tripBookingRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICabRepository cabRepository;
        private readonly IDriverRepository driverRepository;

        public TripBookingService(
            ITripBookingRepository tripBookingRepository,
            ICustomerRepository customerRepository,
            ICabRepository cabRepository,
            IDriverRepository driverRepository)
        {
            this.tripBookingRepository = tripBookingRepository;
            this.customerRepository = customerRepository;
            this.cabRepository = cabRepository;
            this.driverRepository = driverRepository;
        }


        public async Task<TripBooking> AddTripBookingAsync(TripBookingRequest tripBookingRequest)
        {
            List<Customer> allCustomers =  customerRepository.GetAllAsync();

            try
            {
                Customer customer = allCustomers.FirstOrDefault(x => x.EmailId == tripBookingRequest.CustomerEmailId);
                
                TripBooking tripBooking = TripBookingTransformer.TripRequestToTripBooking(tripBookingRequest);

                Cab cab = cabRepository.getRandomAvailableCab();
                if(cab == null)
                {
                    throw new Exception("Sorry no cabs available!");
                }

                tripBooking.TotalFare = tripBookingRequest.TripDistanceInKm * cab.FarePrKm;

                // get the driver to whom cab belongs to 

                tripBooking.Driver = cab.Driver;

                tripBooking.Customer = customer;

                try
                {
                    var trip = await tripBookingRepository.AddAsync(tripBooking);

                    cab.IsAvailable = false;

                    customer.CustomerTripBookingList.Add(tripBooking);
                }catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("issue of review");
                }

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
