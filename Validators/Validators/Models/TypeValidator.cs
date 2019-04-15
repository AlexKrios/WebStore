using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class TypeValidator : AbstractValidator<Type>
    {
        public TypeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");
        }
    }
}
