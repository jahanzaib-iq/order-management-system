
namespace Customer.Domain.Entities;

public class Country
{
  public string CountryId { get; set; } = default!;
  public string CountryName { get; set; } = default!;

  private readonly List<State> _states = [];
  public IReadOnlyCollection<State> States => _states.AsReadOnly();
}
