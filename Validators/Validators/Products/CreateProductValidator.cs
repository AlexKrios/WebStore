﻿using CQS.Commands.Products;
using FluentValidation;

namespace Validators.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description must be entered");

            RuleFor(x => x.Availability)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct availability");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please specify a correct price");

            RuleFor(x => x.TypeId)
                .NotEmpty()
                .WithMessage("Please specify a correct type id");

            RuleFor(x => x.ManufacturerId)
                .NotEmpty()
                .WithMessage("Please specify a correct manufacturer id");
        }
    }
}