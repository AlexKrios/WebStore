using CommandAndQuerySeparation.Queries.Manufacturers;
using FluentValidation;

namespace Validators.Validators.Manufacturers 
{
    public class GetManufacturerByIdValidator : AbstractValidator<GetManufacturerByIdQuery>
    {
        public GetManufacturerByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
