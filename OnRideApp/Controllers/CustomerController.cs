namespace OnRideApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService customerService;
    private readonly ILogger logger;

    public CustomerController(ICustomerService customerService,
        ILogger<CustomerController> logger)
    {
        this.customerService = customerService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerRequest customerRequest)
    {
        try
        {
            var customer = await customerService.AddCustomerAsync(customerRequest);
            return Ok("Customer created");
        }
        catch (Exception ex)
        {
            logger.LogError("{} Error :  {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);

            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest("Error occured while creating customer");
        }
    }

    [HttpGet("/gender/{gender}/age/{age}")]
    public async Task<IActionResult> GetCustomerByGenderAndAgeGreaterThan(
        [FromRoute] Gender gender,
        [FromRoute] int age)
    {
        try
        {
            var customers = await customerService.GetCustomerByGenderAndAgeGreaterThanAsync(gender, age);
            if (customers == null || !customers.Any())
            {
                return NotFound("No related customer found");
            }
            return Ok(customers);
        }
        catch (Exception ex)
        {
            logger.LogError("{} Error: {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);

            return BadRequest("Error occured while fetching customer");
        }
    }
}