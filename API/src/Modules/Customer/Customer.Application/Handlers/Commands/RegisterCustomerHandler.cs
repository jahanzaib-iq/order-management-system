using Customer.Application.Requests.Commands;
using Customer.Application.Responses.Commands;
using Customer.Domain.Entities.Identity;
using Domain.Shared.MediatorReplica;
using Microsoft.AspNetCore.Identity;

namespace Customer.Application.Handlers.Commands
{
  public class RegisterCustomerHandler(UserManager<ApplicationUser> userManager, IGenericRepository<Domain.Entities.Customer> custRepository)
    : IRequestHandler<RegisterCustomerRequest, RegisterCustomerResponse>
  {
    public async Task<RegisterCustomerResponse> Handle(RegisterCustomerRequest command, CancellationToken cancellationToken)
    {
      var user = new ApplicationUser
      {
        UserName = command.Email,
        Email = command.Email
      };

      var result = await userManager.CreateAsync(user, command.Password);

      if (!result.Succeeded)
      {
        var error =  result.Errors.Select(e => e.Description).ToArray();
      }

      var customer = new Domain.Entities.Customer(Guid.NewGuid(), user.Id, command.Email, command.FirstName, command.LastName);
      await custRepository.Insert(customer);
      return new RegisterCustomerResponse { };
    }
  }
}
