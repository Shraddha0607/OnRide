using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos;
using OnRideApp.Models.MyEnums;

namespace OnRideApp.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(CustomerRequest customerRequest);
        Task<IEnumerable<Customer>> GetCustomerByGenderAndAgeGreaterThanAsync(Gender gender, int age);


    }
}
