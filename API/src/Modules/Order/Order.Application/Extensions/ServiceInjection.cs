
using Domain.Shared.MediatorReplica;
using Order.Application.CustomMediator;
using System.Reflection;

namespace Order.Application.Extensions;

public static class ServiceInjection
{
    public static void OrderServiceInjection(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        services.RegisterHandlers(Assembly.GetExecutingAssembly());
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
