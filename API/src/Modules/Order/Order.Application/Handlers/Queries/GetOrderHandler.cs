
using Domain.Shared.MediatorReplica;

namespace Order.Application.Handlers.Queries
{
  public class GetOrderHandler(ILogger<GetOrderHandler> logger, IGenericRepository<OrderEntity.Order> genericRepository)
    : IRequestHandler<GetOrdersRequest, List<OrderEntity.Order>>
  {
    public Task<List<OrderEntity.Order>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
      logger.LogInformation(message: "Fetching orders.");
      return genericRepository.ToListAsync();
    }
  }
}
