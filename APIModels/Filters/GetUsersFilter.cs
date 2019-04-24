using APIModels.Requests.Users;
using DataLibrary.Entities;
using Specification.Specification;

namespace APIModels.Filters
{
    public class GetUsersFilter
    {
        public GetUsersRequest Filter { get; set; }

        public ISpecification<User> HasName =>
            new ExpressionSpecification<User>(o => o.Name.Equals(Filter.Name));

        public ISpecification<User> MinAge =>
            new ExpressionSpecification<User>(o => o.Age >= Filter.MinAge);
        public ISpecification<User> MaxAge =>
            new ExpressionSpecification<User>(o => o.Age <= Filter.MaxAge);

        public ISpecification<User> HasEmail =>
            new ExpressionSpecification<User>(o => o.Email.Equals(Filter.Email));

        public ISpecification<User> CityId =>
            new ExpressionSpecification<User>(o => o.CityId == Filter.CityId);

        public ISpecification<User> HasAll => HasName.And(MinAge).And(MaxAge).And(HasEmail).And(CityId);

        public ISpecification<User> OneOfAll => HasName.Or(MinAge).Or(MaxAge).Or(HasEmail).Or(CityId);

        public GetUsersFilter(GetUsersRequest filter)
        {
            Filter = filter;
        }
    }
}
