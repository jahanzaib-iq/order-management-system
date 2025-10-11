
using Domain.Shared.MediatorReplica;

namespace ManagementSystem.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IDispatcher dispatcher, ILogger<OrderController> logger) : ControllerBase
{
  [HttpGet]
    [ResponseCache()]
  public async Task<IActionResult> Orders()
  {
    throw new Exception();
    var result = await dispatcher.Send(new GetOrdersRequest());
    return Ok(result);
  }


  [HttpPost]
  public async Task<IActionResult> Orders([FromBody] CreateOrderRequest command)
  {
    logger.LogInformation(message: "Request received to create order.");
    await dispatcher.Send(command);
    logger.LogInformation(message: "Order created successfully.");

    return Ok("Order created successfully");
  }
}
