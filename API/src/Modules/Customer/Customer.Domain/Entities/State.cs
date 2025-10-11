
namespace Customer.Domain.Entities;

public class State
{
  public string StateId { get; set; } = default!;
  public string StateName { get; set; } = default!;

  public string CountryId { get; set; } = default!;
  public Country Country { get; set; } = default!;

  private readonly List<City> _cities = [];
  public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();
}
