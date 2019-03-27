namespace WebStoreAPI.Queries.Users
{
    //Get single user command
    public class GetSingleUserQueries : IQuery
    {
        public int Id { get; }

        public GetSingleUserQueries(int id)
        {
            Id = id;
        }
    }
}
