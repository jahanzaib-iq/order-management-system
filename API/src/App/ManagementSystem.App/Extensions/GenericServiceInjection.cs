
using ExceptionHandler;

namespace ManagementSystem.App.Extensions;

public static class GenericServiceInjection
{
  public static void ConfigureGenericServiceInjection(this IServiceCollection services)
  {
    services.AddHttpContextAccessor();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddHttpLogging(logging => logging.LoggingFields = HttpLoggingFields.All);

    services.AddExceptionHandler<GlobalExceptionHandler>();
    services.AddExceptionHandler<ValidationExceptionHandler>();
    services.AddProblemDetails(configure =>
    {
      configure.CustomizeProblemDetails = context =>
      {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
      };
    });
  }
}
