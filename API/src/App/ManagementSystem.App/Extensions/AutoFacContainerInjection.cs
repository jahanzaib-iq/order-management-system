
namespace ManagementSystem.App.Extensions;

public static class AutoFacContainerInjection
{
  public static void ConfigureAutoFacContainer(this WebApplicationBuilder appBuilder)
  {
    appBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    
    appBuilder.Host.ConfigureContainer<ContainerBuilder>(b =>
    {
      b.RegisterModule<RegisterOrderInfrastructure>();
      b.RegisterModule<RegisterCustomerInfrastructure>();
    });
  }
}
