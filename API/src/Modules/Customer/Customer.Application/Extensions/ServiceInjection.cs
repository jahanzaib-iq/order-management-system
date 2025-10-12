

using Customer.Domain.Entities.Identity;
using Customer.Infrastructure.Data;
using Domain.Shared.MediatorReplica;
using Microsoft.AspNetCore.Identity;

namespace Customer.Application.Extensions;

public static class ServiceInjection
{
  public static void CustomerServiceInjection(this IServiceCollection services)
  {
    services.AddScoped<IDispatcher, Dispatcher>();
    services.RegisterHandlers(Assembly.GetExecutingAssembly());

    services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
    {
      options.Password.RequiredLength = 8;
      options.User.RequireUniqueEmail = true;
    })
        .AddEntityFrameworkStores<CustomerDbContext>()
        .AddDefaultTokenProviders();

  }

  private static IServiceCollection RegisterHandlers(this IServiceCollection services, Assembly assembly)
  {
    var handlerTypes = assembly.GetTypes()
        .Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType &&
                      i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
        .ToList();

    foreach (var handlerType in handlerTypes)
    {
      var interfaceType = handlerType.GetInterfaces()
          .First(i => i.IsGenericType &&
                     i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

      services.AddScoped(interfaceType, handlerType);
    }

    return services;
  }
}
