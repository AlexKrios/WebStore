namespace WebStoreAPI.Queries.Users
{
    //Get single user command
    public class GetSingleUserCommand : IQuery
    {
        public int Id { get; }

        public GetSingleUserCommand(int id)
        {
            Id = id;
        }
    }
}
