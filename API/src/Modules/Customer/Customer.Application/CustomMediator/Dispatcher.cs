
using Domain.Shared.MediatorReplica;

namespace Customer.Application.CustomMediator;

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{

  public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
  {
    var requestType = request.GetType();

    var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

    var handler = serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"No handler found for {requestType.Name}");

    var method = handlerType.GetMethod("Handle");

    var responseTask = (Task<TResponse>)method!.Invoke(handler, new object[] { request, cancellationToken })!;

    return await responseTask;
  }
}
