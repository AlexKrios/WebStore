using FluentValidation;
using WebStoreAPI.Requests.Users;

namespace Validators.Validators.Users 
{
    public class GetAllUsersByIdValidator : AbstractValidator<GetUsersRequest>
    {
        public GetAllUsersByIdValidator()
        {
            
        }
    }
}
