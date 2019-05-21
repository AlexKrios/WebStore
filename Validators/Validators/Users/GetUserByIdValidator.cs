using FluentValidation;
using WebStoreAPI.Requests.Users;

namespace Validators.Validators.Users 
{
    public class GetUserByIdValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id must be entered");
        }
    }
}
