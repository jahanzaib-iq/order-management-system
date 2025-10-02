
namespace Order.Domain.Interfaces.Handlers;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
  Task HandleAsync(TCommand command);
}
