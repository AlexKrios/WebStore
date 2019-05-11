using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetUsersFilter
    {
        public GetUsersRequest Request { get; set; }

        public ISpecification<User> NameEquals =>
            new ExpressionSpecification<User>(o => o.Name.Equals(Request.Name));

        public ISpecification<User> MinAge =>
            new ExpressionSpecification<User>(o => o.Age >= Request.MinAge);
        public ISpecification<User> MaxAge =>
            new ExpressionSpecification<User>(o => o.Age <= Request.MaxAge);

        public ISpecification<User> EmailEquals =>
            new ExpressionSpecification<User>(o => o.Email.Equals(Request.Email));

        public ISpecification<User> CityId =>
            new ExpressionSpecification<User>(o => o.CityId == Request.CityId);
    }
}
