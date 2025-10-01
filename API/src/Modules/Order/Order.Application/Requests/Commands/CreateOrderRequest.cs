
namespace Order.Application.Requests.Commands;

public class CreateOrderRequest : ICommand
{
  public string CustomerName { get; set; } = string.Empty;

  public string Product { get; set; } = string.Empty;

  public decimal Price { get; set; }

  public int StatusId { get; set; }

}
