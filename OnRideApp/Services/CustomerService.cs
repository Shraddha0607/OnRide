namespace OnRideApp.Services;

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
            .AsNoTracking()
            .Where(x => x.Gender == gender && x.Age > age)
            .ToListAsync();

        if (allCustomers == null)
        {
            throw new CustomException("No such customer found");
        }
        return allCustomers;
    }
}