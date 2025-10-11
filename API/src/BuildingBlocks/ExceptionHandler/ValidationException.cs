using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ExceptionHandler;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    if (exception is not ValidationException validationException)
    {
      return false;
    }

    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
    var context = new ProblemDetailsContext
    {
      HttpContext = httpContext,
      Exception = exception,
      ProblemDetails = new ProblemDetails
      {
        Title = "One or more validation errors occurred.",
        Status = StatusCodes.Status400BadRequest,
        Instance = httpContext.Request.Path,
        Detail = validationException.Message

      }
    };

    ////var errors = validationException.Errors
    ////  .GroupBy(e => e.PropertyName)
    ////  .ToDictionary(
    ////    g => g.Key.ToLowerInvariant(),
    ////    g => g.Select(e => e.ErrorMessage).ToArray()
    ////  );

    var errors = validationException.ValidationResult.ErrorMessage;

    context.ProblemDetails.Extensions.Add("errors", errors);
    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(context, options: new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    }), cancellationToken: cancellationToken);

    return true;

  }
}
