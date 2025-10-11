
using Domain.Shared.MediatorReplica;

namespace Order.Application.Requests.Queries;

public class GetOrdersRequest : IRequest<List<Domain.Entities.Order>>
{
}
