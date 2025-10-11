
namespace Customer.Infrastructure.Repositories;

public class RegisterCustomerInfrastructure : Autofac.Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<CustomerDbContext>().As<ICustomerDbContext>().InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
    builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerDependency();

    base.Load(builder);
  }
}
