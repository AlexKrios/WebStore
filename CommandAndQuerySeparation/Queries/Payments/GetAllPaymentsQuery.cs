using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CommandAndQuerySeparation.Queries.Payments
{
    public class GetAllPaymentsQuery : IRequest<IEnumerable<Payment>>
    {

    }
}
