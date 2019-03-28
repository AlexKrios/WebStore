using FluentValidation;

namespace WebStoreAPI.Models
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(t => t.Id).NotEmpty();
            //RuleFor(t => t.FirstName).NotEmpty().Length(1, 50);
            //RuleFor(t => t.LastName).NotEmpty().Length(1, 50);
            //RuleFor(t => t.Role).NotEmpty().Length(1, 50);
            //RuleFor(t => t.Age);
        }
    }
}
