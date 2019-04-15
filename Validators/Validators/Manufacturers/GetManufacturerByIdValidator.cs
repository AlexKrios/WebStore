using CQS.Queries.Manufacturers;
using FluentValidation;

namespace Validators.Validators.Manufacturers 
{
    public class GetManufacturerByIdValidator : AbstractValidator<GetManufacturerQuery>
    {
        public GetManufacturerByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
