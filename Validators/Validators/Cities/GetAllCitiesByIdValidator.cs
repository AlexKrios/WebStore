using CommandAndQuerySeparation.Queries.Cities;
using FluentValidation;

namespace Validators.Validators.Cities 
{
    public class GetAllCitiesByIdValidator : AbstractValidator<GetAllCitiesQuery>
    {
        public GetAllCitiesByIdValidator()
        {

        }
    }
}
