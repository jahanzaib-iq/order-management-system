
using Customer.Infrastructure.Extensions;
namespace ManagementSystem.App.Extensions;

public static class OrderServiceInjection
{

  public static void ConfigureApplicationService(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddOrderDbContext(configuration);
    services.AddCustomerDbContext(configuration);
    services.ConfigureApplicationServiceInjection();

    services.AddHttpContextAccessor();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddHttpLogging(logging => logging.LoggingFields = HttpLoggingFields.All);
  }
}
