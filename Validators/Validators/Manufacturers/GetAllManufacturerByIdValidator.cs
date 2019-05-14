using FluentValidation;
using WebStoreAPI.Requests.Manufacturers;

namespace Validators.Validators.Manufacturers
{
    public class GetAllManufacturerByIdValidator : AbstractValidator<GetManufacturersRequest>
    {
        public GetAllManufacturerByIdValidator()
        {
            
        }
    }
}