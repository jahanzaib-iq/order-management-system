

namespace ManagementSystem.App.Extensions;

public static class OrderServiceInjection
{

  public static void ConfigureOrderApplicationService(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddOrderDbContext(configuration);
    services.OrderServiceInjection();
  }
}
