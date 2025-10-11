
using Customer.Application.Responses.Queries;
using Domain.Shared.MediatorReplica;

namespace Customer.Application.Handlers.Queries;

public class GetCustomersHandler(ILogger<GetCustomersHandler> logger, IGenericRepository<Domain.Entities.Customer> genericRepository)
  : IRequestHandler<GetCustomersRequest, List<GetCustomersResponse>>
{
  public async Task<List<GetCustomersResponse>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
  {
    logger.LogInformation(message: "Fetching customers.");
    var result = await genericRepository.ToListAsync();

    return [];
  }
}
