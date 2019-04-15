using CQS.Queries.Users;
using FluentValidation;

namespace Validators.Validators.Users 
{
    public class GetUserByIdValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
