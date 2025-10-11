using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Entities;

public class Address(string line1, string postalCode, string cityId, string stateId, string countryId)
{
  private Address() : this(default!, default!, default!, default!, default!) { }

  public Guid Id { get; private set; } = Guid.NewGuid();
  public string Line1 { get; private set; } = line1;
  public string PostalCode { get; private set; } = postalCode;
  public string CityId { get; private set; } = cityId;
  public string StateId { get; private set; } = stateId;
  public string CountryId { get; private set; } = countryId;

  public Guid CustomerId { get; private set; }
  public Customer Customer { get; private set; } = default!;
  public City City { get; private set; } = default!;
  public State State { get; private set; } = default!;
  public Country Country { get; private set; } = default!;
}

