
namespace Order.Application.CustomMediatR;

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
  public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
  {
    var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
    return await handler.HandleAsync(query);
  }

  public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
  {
    var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
    await handler.HandleAsync(command);
  }
}
