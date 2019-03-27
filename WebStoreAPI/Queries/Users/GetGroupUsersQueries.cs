namespace WebStoreAPI.Queries.Users
{
    //Get group of users command
    public class GetGroupUsersQueries : IQuery
    {
        public string Role { get; }

        public GetGroupUsersQueries(string role)
        {
            Role = role;
        }
    }
}
