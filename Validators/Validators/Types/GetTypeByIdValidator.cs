using CommandAndQuerySeparation.Queries.Types;
using FluentValidation;

namespace Validators.Validators.Types 
{
    public class GetTypeByIdValidator : AbstractValidator<GetTypeByIdQuery>
    {
        public GetTypeByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
