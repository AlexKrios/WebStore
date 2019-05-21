using FluentValidation;
using WebStoreAPI.Requests.Cities;

namespace Validators.Validators.Cities 
{
    public class GetAllCitiesByIdValidator : AbstractValidator<GetCitiesRequest>
    {
        public GetAllCitiesByIdValidator()
        {

        }
    }
}
