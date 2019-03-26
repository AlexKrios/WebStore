namespace WebStoreAPI.Queries.Products
{
    public class GetSingleProduct<T> : IGetSingle<T>
    {
        public virtual T Execute(int id)
        {
            return default(T);
        }
    }
}
