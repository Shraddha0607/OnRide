namespace OnRideApp.Services;

public interface ICustomerService
{
    Task<Customer> AddCustomerAsync(CustomerRequest customerRequest);

    Task<IEnumerable<Customer>> GetCustomerByGenderAndAgeGreaterThanAsync(Gender gender, int age);
}