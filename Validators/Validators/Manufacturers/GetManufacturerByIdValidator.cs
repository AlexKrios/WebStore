using FluentValidation;
using WebStoreAPI.Requests.Manufacturers;

namespace Validators.Validators.Manufacturers 
{
    public class GetManufacturerByIdValidator : AbstractValidator<GetManufacturerRequest>
    {
        public GetManufacturerByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
