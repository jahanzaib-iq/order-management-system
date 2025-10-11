

using Customer.Application.Requests.Commands;
using Domain.Shared.MediatorReplica;

namespace ManagementSystem.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(IDispatcher dispatcher, ILogger<CustomerController> logger) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> Customer()
  {
    var result = await dispatcher.Send(new GetCustomersRequest { });
    return Ok(result);
  }

  [HttpPost]
  public async Task<IActionResult> Customer([FromBody] RegisterCustomerRequest request)
  {
    await dispatcher.Send(request);
    logger.LogInformation(message: "Customer registered successfully.");

    return Ok("Customer registered successfully");
  }

    [HttpPost("login")]
    public async Task<IActionResult> Customer([FromBody] LoginRequest request)
    {
        await dispatcher.Send(request);
        logger.LogInformation(message: "Customer loggedIn successfully.");

        return Ok("Customer LoggedIn successfully");

    }
}
