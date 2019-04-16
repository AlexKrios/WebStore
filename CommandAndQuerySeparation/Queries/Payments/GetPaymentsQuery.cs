using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Payments
{
    public class GetPaymentsQuery : IRequest<IEnumerable<Payment>>
    {

    }
}
