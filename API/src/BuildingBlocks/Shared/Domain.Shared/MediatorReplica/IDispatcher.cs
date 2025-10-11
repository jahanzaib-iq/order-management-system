namespace Domain.Shared.MediatorReplica;

public interface IDispatcher
{
  Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
