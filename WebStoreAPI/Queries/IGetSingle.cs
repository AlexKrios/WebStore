namespace WebStoreAPI.Queries
{
    public interface IGetSingle<out T>
    {
        T Execute(int id);
    }
}
