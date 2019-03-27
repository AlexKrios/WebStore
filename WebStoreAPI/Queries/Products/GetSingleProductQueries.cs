namespace WebStoreAPI.Queries.Products
{
    //Get single product command
    public class GetSingleProductQueries : IQuery
    {
        public int Id { get; }

        public GetSingleProductQueries(int id)
        {
            Id = id;
        }
    }
}
