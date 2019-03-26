namespace WebStoreAPI.Queries.Products
{
    public class GetAllProducts<T> : IGetAll<T>
    {
        public virtual T Execute()
        {
            return default(T);
        }
    }
}
