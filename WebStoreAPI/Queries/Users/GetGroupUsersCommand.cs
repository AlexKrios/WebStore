namespace WebStoreAPI.Queries.Users
{
    //Get group of users command
    public class GetGroupUsersCommand : IQuery
    {
        public string Role { get; }

        public GetGroupUsersCommand(string role)
        {
            Role = role;
        }
    }
}
