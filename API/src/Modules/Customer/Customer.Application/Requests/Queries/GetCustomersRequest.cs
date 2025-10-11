using Customer.Application.Responses.Queries;
using Domain.Shared.MediatorReplica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Requests.Queries
{
  public class GetCustomersRequest : IRequest<List<GetCustomersResponse>>
  {
  }
}
