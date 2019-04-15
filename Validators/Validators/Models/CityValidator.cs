using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must be entered");

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("Please specify a correct country id");
        }
    }
}
