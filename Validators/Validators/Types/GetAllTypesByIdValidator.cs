using CommandAndQuerySeparation.Queries.Types;
using FluentValidation;

namespace Validators.Validators.Types 
{
    public class GetAllTypesByIdValidator : AbstractValidator<GetAllTypesQuery>
    {
        public GetAllTypesByIdValidator()
        {
            
        }
    }
}
