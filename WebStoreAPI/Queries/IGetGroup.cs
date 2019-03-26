namespace WebStoreAPI.Queries
{
    public interface IGetGroup<out T>
    {
        T Execute(string type);
    }
}
