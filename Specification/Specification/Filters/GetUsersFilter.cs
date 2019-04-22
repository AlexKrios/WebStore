using DataLibrary.Entities;
using Specification.Requests.Users;

namespace Specification.Specification.Filters
{
    public class GetUsersFilter
    {
        public static GetUsersRequest Filter { get; set; }

        public static ISpecification<User> HasName =
            new ExpressionSpecification<User>(o => o.Name.Equals(Filter.Name));

        public static ISpecification<User> MinAge =
            new ExpressionSpecification<User>(o => o.Age >= Filter.MinAge);
        public static ISpecification<User> MaxAge =
            new ExpressionSpecification<User>(o => o.Age <= Filter.MaxAge);

        public static ISpecification<User> HasEmail =
            new ExpressionSpecification<User>(o => o.Email.Equals(Filter.Email));

        public static ISpecification<User> CityId =
            new ExpressionSpecification<User>(o => o.CityId == Filter.CityId);

        public ISpecification<User> OneOfAll = HasName.Or(MinAge).Or(MaxAge).Or(HasEmail).Or(CityId);

        public GetUsersFilter(GetUsersRequest filter)
        {
            Filter = filter;
        }
    }
}
