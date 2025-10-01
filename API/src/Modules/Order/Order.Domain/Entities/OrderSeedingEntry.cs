
namespace Order.Domain.Entities;

public class OrderSeedingEntry(string name)
{
  public string Name { get; set; } = name;
}
