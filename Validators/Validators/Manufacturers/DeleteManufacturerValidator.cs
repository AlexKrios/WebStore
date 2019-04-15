using CommandAndQuerySeparation.Commands.Manufacturers;
using FluentValidation;

namespace Validators.Validators.Manufacturers
{
    public class DeleteManufacturerValidator : AbstractValidator<DeleteManufacturerCommand>
    {
        public DeleteManufacturerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Input correct id");
        }
    }
}