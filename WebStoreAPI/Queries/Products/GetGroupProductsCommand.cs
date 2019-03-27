namespace WebStoreAPI.Queries.Products
{
    //Get group of products command
    public class GetGroupProductsCommand : IQuery
    {
        public string Type { get; }

        public GetGroupProductsCommand(string type)
        {
            Type = type;
        }
    }
}
