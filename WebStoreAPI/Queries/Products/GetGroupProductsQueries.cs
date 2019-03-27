namespace WebStoreAPI.Queries.Products
{
    //Get group of products command
    public class GetGroupProductsQueries : IQuery
    {
        public string Type { get; }

        public GetGroupProductsQueries(string type)
        {
            Type = type;
        }
    }
}
