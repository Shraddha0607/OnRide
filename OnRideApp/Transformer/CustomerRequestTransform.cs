using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Models.Dtos.Response;

namespace OnRideApp.Transformer;

public class CustomerRequestTransformer
{
    public static Customer CustomerRequestToCustomer(CustomerRequest customerRequest)
    {
        return new Customer
        {
            Name = customerRequest.Name,
            Age = customerRequest.Age,
            EmailId = customerRequest.EmailId,
            Address = customerRequest.Address,
            Gender = customerRequest.Gender
        };
    }

    public static CustomerResponse CustomerToCustomerResponse(Customer customer)
    {
        return new CustomerResponse
        {
            Name = customer.Name,
            EmailId = customer.EmailId
        };
    }
}
