
namespace Order.Infrastructure.Repositories;

public class RegisterRepositories : Autofac.Module
{
  protected override void Load(ContainerBuilder builder)
  {
    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

    builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerDependency();

    base.Load(builder);
  }
}
