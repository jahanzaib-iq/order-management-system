
namespace Customer.Domain.Entities;

public class City
{
  public string CityId { get; set; } = default!;
  public string CityName { get; set; } = default!;

  public string StateId { get; set; } = default!;
  public State State { get; set; } = default!;
}
