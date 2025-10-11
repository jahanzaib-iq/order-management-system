
namespace Order.Infrastructure.Repositories;

public class RegisterOrderInfrastructure : Autofac.Module
{
  protected override void Load(ContainerBuilder builder)
  {

    builder.RegisterType<OrderDbContext>().As<IOrderDbContext>().InstancePerLifetimeScope();
    builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
    
    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

    builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerDependency();

    base.Load(builder);
  }
}
