
namespace ManagementSystem.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(IDispatcher dispatcher, ILogger<OrderController> logger) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> Orders()
  {
    var result = await dispatcher.QueryAsync<GetOrdersRequest, List<OrderEntity.Order>>(new GetOrdersRequest { });
    return Ok(result);
  }


  [HttpPost]
  public async Task<IActionResult> Orders([FromBody] CreateOrderRequest command)
  {
    logger.LogInformation(message: "Request received to create order.");
    await dispatcher.SendAsync(command);
    logger.LogInformation(message: "Order created successfully.");

    return Ok("Order created successfully");
  }
}
