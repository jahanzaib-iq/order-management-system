using Order.Domain.Enums;

namespace Order.Domain.Entities;

public class Order : BaseEntity
{
  public int Id { get; set; }

  public string CustomerName { get; set; } = string.Empty;

  public string Product { get; set; } = string.Empty;

  public decimal Price { get; set; }

  public int StatusId { get; set; }
  public OrderStatus Status { get; set; }
}
