namespace WebStoreAPI.Commands
{
    public interface ICommandService<T>
    {
        void Post(T product);
        void Put(T product);
        void Delete(T product);
        void SaveDB();
    }
}
