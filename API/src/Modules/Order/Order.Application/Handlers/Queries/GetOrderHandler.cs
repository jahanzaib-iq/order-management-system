
namespace Order.Application.Handlers.Queries
{
  public class GetOrderHandler(ILogger<GetOrderHandler> logger, IGenericRepository<OrderEntity.Order> genericRepository)
    : IQueryHandler<GetOrdersRequest, List<OrderEntity.Order>>
  {
    public Task<List<OrderEntity.Order>> HandleAsync(GetOrdersRequest query)
    {
      logger.LogInformation(message: "Fetching orders.");
      return genericRepository.ToListAsync();
    }
  }
}
