using CommandAndQuerySeparation.Queries.Users;
using FluentValidation;

namespace Validators.Validators.Users 
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
