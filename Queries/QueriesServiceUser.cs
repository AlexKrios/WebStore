using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries
{
    //Querie class for User
    public class QueriesServiceUser : Controller, IQueriesService<User>
    {
        private readonly WebStoreContext context;
        public QueriesServiceUser(WebStoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }
        public User GetSingle(int id)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public IEnumerable<User> GetGroup(string str)
        {
            IEnumerable<User> users = context.Users.Where(x => x.Role == str);
            return users.ToList();
        }
    }
}
