using DataLibrary.Entities;
using Specification.Requests.Payments;

namespace Specification.Specification.Filters
{
    public class GetPaymentsFilter
    {
        public static GetPaymentsRequest Filter { get; set; }

        public static ISpecification<Payment> HasName =
            new ExpressionSpecification<Payment>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<Payment> MinTaxes =
            new ExpressionSpecification<Payment>(o => o.Taxes >= Filter.MinTaxes);
        public static ISpecification<Payment> MaxTaxes =
            new ExpressionSpecification<Payment>(o => o.Taxes <= Filter.MaxTaxes);

        public ISpecification<Payment> OneOfAll = HasName.Or(MinTaxes).Or(MaxTaxes);

        public GetPaymentsFilter(GetPaymentsRequest filter)
        {
            Filter = filter;
        }
    }
}
