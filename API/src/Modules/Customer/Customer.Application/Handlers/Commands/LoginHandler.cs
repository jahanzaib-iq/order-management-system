using Customer.Application.Requests.Commands;
using Customer.Application.Responses.Commands;
using Customer.Domain.Entities.Identity;
using Domain.Shared.MediatorReplica;
using Microsoft.AspNetCore.Identity;

namespace Customer.Application.Handlers.Commands
{
  public class LoginHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<LoginRequest, LoginResponse>
  {
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
      var user = await userManager.FindByEmailAsync(request.Email);

      // Generate Token Service

      return new LoginResponse { };
    }
  }
}
