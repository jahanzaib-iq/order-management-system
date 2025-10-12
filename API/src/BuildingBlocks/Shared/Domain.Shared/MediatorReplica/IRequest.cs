
namespace Domain.Shared.MediatorReplica;

public interface IRequest : IBaseRequest { }

public interface IRequest<out TResponse> : IBaseRequest { }


