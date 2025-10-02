
using Order.Domain.Interfaces.Repositories;

namespace ManagementSystem.App.Extensions;

public static class AutoFacContainerInjection
{
  public static void ConfigureAutoFacContainer(this WebApplicationBuilder appBuilder)
  {
    appBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    appBuilder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterType<OrderDbContext>().As<IOrderDbContext>().InstancePerLifetimeScope());
    appBuilder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope());
    appBuilder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RegisterRepositories()));
  }
}
