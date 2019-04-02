﻿using FluentValidation;
using WebStoreAPI.Commands.Users;

namespace WebStoreAPI.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct first name");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct last name");

            RuleFor(x => x.Role)
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Please specify a correct role");

            RuleFor(x => x.Age)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Please specify correct age");
        }
    }
}
