using CQS.Queries.Cities;
using FluentValidation;

namespace Validators.Validators.Cities 
{
    public class GetAllCitiesByIdValidator : AbstractValidator<GetCitiesQuery>
    {
        public GetAllCitiesByIdValidator()
        {

        }
    }
}
