using FluentValidation;
using WebStoreAPI.Requests.Countries;

namespace Validators.Validators.Countries 
{
    public class GetAllCountryByIdValidator : AbstractValidator<GetCountriesRequest>
    {
        public GetAllCountryByIdValidator()
        {
            
        }
    }
}
