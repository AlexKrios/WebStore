using WebStoreAPI.Models;

namespace WebStoreAPI.Commands
{
    //Processing command request for user
    public class CommandServiceUser : ICommandService<User>
    {
        private readonly WebStoreContext db;
        public CommandServiceUser(WebStoreContext db)
        {
            this.db = db;
        }
        public void Post(User user)
        {
            db.Users.Add(user);
        }
        public void Put(User product)
        {
            db.Update(product);
        }
        public void Delete(User user)
        {
            db.Users.Remove(user);
        }
        public void SaveDB()
        {
            db.SaveChanges();
        }
    }
}
