using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace WebStoreAPI.Queries.Payments
{
    public class GetAllPaymentsQuery : IRequest<IEnumerable<Payment>>
    {
    }
}
