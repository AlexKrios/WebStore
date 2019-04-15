using CommandAndQuerySeparation.Queries.Manufacturers;
using FluentValidation;

namespace Validators.Validators.Manufacturers
{
    public class GetAllManufacturerByIdValidator : AbstractValidator<GetManufacturersQuery>
    {
        public GetAllManufacturerByIdValidator()
        {
            
        }
    }
}