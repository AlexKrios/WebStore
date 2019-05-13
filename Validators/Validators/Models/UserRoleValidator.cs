using DataLibrary.Entities;
using FluentValidation;

namespace Validators.Validators.Models
{
    public class UserRoleValidator : AbstractValidator<DataLibrary.Entities.UserRoles>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("Please specify a correct user id");

            RuleFor(x => x.RoleId)
                .NotEmpty()
                .WithMessage("Please specify a correct role id");
        }
    }
}
