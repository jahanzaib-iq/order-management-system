
namespace Customer.Domain.Entities;

public class Customer(Guid id, Guid userId, string email, string firstName, string lastName) : BaseEntity
{

  private Customer() : this(default!,default!, default!, default!, default!) { }
  public Guid CustomerId { get; set; } = id;
  public string Email { get; private set; } = email;
  public string FirstName { get; private set; } = firstName;
  public string LastName { get; private set; } = lastName;
  public Guid UserId { get; private set; } = userId;
  public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
  private List<Address> _addresses = [];

  public void UpdateProfile(string firstName, string lastName)
  {
    FirstName = firstName;
    LastName = lastName;
  }

  public void AddAddress(Address address)
  {
    ArgumentNullException.ThrowIfNull(address);

    _addresses.Add(address);
  }

  public void RemoveAddress(Guid addressId) => _addresses.RemoveAll(a => a.Id == addressId);
}
