using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        List<Customer> GetAllAsync();
    }
}
