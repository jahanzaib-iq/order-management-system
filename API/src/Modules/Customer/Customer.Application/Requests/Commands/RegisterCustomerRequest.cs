
using Customer.Application.Responses.Commands;
using Domain.Shared.MediatorReplica;

namespace Customer.Application.Requests.Commands
{
  public class RegisterCustomerRequest : IRequest<RegisterCustomerResponse>
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
