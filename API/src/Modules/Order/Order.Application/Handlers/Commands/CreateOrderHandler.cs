
using Domain.Shared.MediatorReplica;
using Order.Application.Responses;

namespace Order.Application.Handlers.Commands
{
  public class CreateOrderHandler(ILogger<CreateOrderHandler> logger, IGenericRepository<OrderEntity.Order> genericRepo) : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
  {
    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
      OrderEntity.Order order = ConvertCommandToDbEntity(request);

      await genericRepo.Insert(order);

      logger.LogInformation(message: "Order created.");

      return new CreateOrderResponse { OrderId = order.Id };
    }

    private static OrderEntity.Order ConvertCommandToDbEntity(CreateOrderRequest command)
    {
      return new OrderEntity.Order
      {
        CustomerName = command.CustomerName,
        Product = command.Product,
        Price = command.Price,
        StatusId = command.StatusId,
        CreatedOn = DateTime.Now
      };
    }
  }
}
