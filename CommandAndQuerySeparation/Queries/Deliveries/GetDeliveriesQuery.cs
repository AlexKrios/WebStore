﻿using System.Collections.Generic;
using DataLibrary.Entities;
using MediatR;

namespace CQS.Queries.Deliveries
{
    public class GetDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
        
    }
}