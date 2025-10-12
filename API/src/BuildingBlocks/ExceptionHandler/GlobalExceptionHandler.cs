using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;


namespace ExceptionHandler;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
  : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    logger.LogError(exception, "Unhandled exception occurred.");

    var statusCode = exception switch
    {
      ArgumentException => StatusCodes.Status400BadRequest,
      FormatException => StatusCodes.Status400BadRequest,
      InvalidCastException => StatusCodes.Status400BadRequest,
      JsonException => StatusCodes.Status400BadRequest,
      InvalidOperationException => StatusCodes.Status400BadRequest,

      UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

      AccessViolationException => StatusCodes.Status403Forbidden,

      KeyNotFoundException => StatusCodes.Status404NotFound,
      FileNotFoundException => StatusCodes.Status404NotFound,
      DirectoryNotFoundException => StatusCodes.Status404NotFound,
      FileLoadException => StatusCodes.Status404NotFound,

      NotSupportedException => StatusCodes.Status405MethodNotAllowed,

      TimeoutException => StatusCodes.Status408RequestTimeout,
      TaskCanceledException => StatusCodes.Status408RequestTimeout,

      NotImplementedException => StatusCodes.Status415UnsupportedMediaType,

      ValidationException => StatusCodes.Status422UnprocessableEntity,

      OperationCanceledException => StatusCodes.Status429TooManyRequests,

      _ => StatusCodes.Status500InternalServerError
    };

    var problemDetails = new ProblemDetails
    {
      Type = exception.GetType().Name,
      Title = "An error occurred",
      Detail = exception.Message,
      Status = statusCode
    };

    httpContext.Response.ContentType = "application/problem+json";
    httpContext.Response.StatusCode = statusCode;

    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails, options: new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    }), cancellationToken: cancellationToken);

    return true;
  }
}
