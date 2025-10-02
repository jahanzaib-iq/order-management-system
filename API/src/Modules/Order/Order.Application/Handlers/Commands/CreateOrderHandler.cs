
namespace Order.Application.Handlers.Commands
{
  public class CreateOrderHandler(ILogger<CreateOrderHandler> logger, IGenericRepository<OrderEntity.Order> genericRepo) : ICommandHandler<CreateOrderRequest>
  {
    public async Task HandleAsync(CreateOrderRequest command)
    {
      OrderEntity.Order order = ConvertCommandToDbEntity(command);

      await genericRepo.Insert(order);

      logger.LogInformation(message: "Order created.");
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
