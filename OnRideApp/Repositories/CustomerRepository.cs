using System.Collections;
using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.MyEnums;

namespace OnRideApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RideDbContext rideDbContext;

        public CustomerRepository(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await rideDbContext.AddAsync(customer);
            await rideDbContext.SaveChangesAsync();
            return customer;
        }

        public List<Customer> GetAllAsync()
        {
            var customers =   rideDbContext.Customers.ToList();
            return customers;
        }
    }
}
