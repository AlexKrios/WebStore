using CommandAndQuerySeparation.Queries.Countries;
using FluentValidation;

namespace Validators.Validators.Countries 
{
    public class GetAllCountryByIdValidator : AbstractValidator<GetCountriesQuery>
    {
        public GetAllCountryByIdValidator()
        {
            
        }
    }
}
