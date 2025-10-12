
using Customer.Application.Responses.Commands;
using Domain.Shared.MediatorReplica;

namespace Customer.Application.Requests.Commands;

public class LoginRequest(string email, string password) : IRequest<LoginResponse>
{
  public string Email { get; set; } = email;
  public string Password { get; set; } = password;
}
