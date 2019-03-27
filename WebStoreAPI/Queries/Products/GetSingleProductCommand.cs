namespace WebStoreAPI.Queries.Products
{
    //Get single product command
    public class GetSingleProductCommand : IQuery
    {
        public int Id { get; }

        public GetSingleProductCommand(int id)
        {
            Id = id;
        }
    }
}
