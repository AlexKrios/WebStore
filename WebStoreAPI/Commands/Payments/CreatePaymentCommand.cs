﻿using MediatR;

namespace WebStoreAPI.Commands.Payments
{
    public class CreatePaymentCommand : IRequest<CreatePaymentCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Taxes { get; set; }
    }
}
