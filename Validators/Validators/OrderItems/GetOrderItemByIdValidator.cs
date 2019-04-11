﻿using CommandAndQuerySeparation.Queries.OrderItems;
using FluentValidation;

namespace Validators.Validators.OrderItems 
{
    public class GetOrderItemByIdValidator : AbstractValidator<GetOrderItemsByIdQuery>
    {
        public GetOrderItemByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
