using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Models.MyEnums;
using OnRideApp.Services;

namespace OnRideApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<string> createCustomer(CustomerRequest customerRequest)
        {
            var customer = await customerService.AddCustomerAsync(customerRequest);
            return "Customer created";
        }

        [HttpGet("/gender/{gender}/age/{age}")]
        public async Task<IEnumerable<Customer>> GetCustomerByGenderAndAgeGreaterThan(
            [FromRoute] Gender gender,
            [FromRoute] int age)
        {
            var customers = await customerService.GetCustomerByGenderAndAgeGreaterThanAsync(gender, age);
            return customers;
        }

    }
}
