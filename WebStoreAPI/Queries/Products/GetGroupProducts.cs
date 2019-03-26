namespace WebStoreAPI.Queries.Products
{
    public class GetGroupProducts<T> : IGetGroup<T>
    {
        public virtual T Execute(string str)
        {
            return default(T);
        }
    }
}
