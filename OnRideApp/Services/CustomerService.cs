using Microsoft.EntityFrameworkCore;
using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Models.MyEnums;
using OnRideApp.Transformer;

namespace OnRideApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly RideDbContext rideDbContext;

        public CustomerService(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<Customer> AddCustomerAsync(CustomerRequest customerRequest)
        {
            Customer customer = CustomerRequestTransformer.CustomerRequestToCustomer(customerRequest);
            await rideDbContext.Customers.AddAsync(customer);
            await rideDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerByGenderAndAgeGreaterThanAsync(Gender gender, int age)
        {
            var allCustomers = await rideDbContext.Customers
                                        .Where(x => x.Gender == gender && x.Age == age)
                                        .ToListAsync();
            if(allCustomers == null)
            {
                throw new Exception("No such customer found");
            }
            return allCustomers;
        }
    }
}
