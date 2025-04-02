using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Models.MyEnums;
using OnRideApp.Repositories;
using OnRideApp.Transformer;

namespace OnRideApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(CustomerRequest customerRequest)
        {
            Customer customer = CustomerRequestTransformer.CustomerRequestToCustomer(customerRequest);
            var createdDriver = await customerRepository.AddAsync(customer);
            return createdDriver;
        }

        public async Task<IEnumerable<Customer>> GetCustomerByGenderAndAgeGreaterThanAsync(Gender gender, int age)
        {
            var allCustomers = customerRepository.GetAllAsync();
            var customer = allCustomers.Where(x => x.Gender == gender && x.Age == age);
            return customer;
        }
    }
}
