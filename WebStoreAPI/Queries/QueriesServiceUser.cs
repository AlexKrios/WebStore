using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStoreAPI.Models;

namespace WebStoreAPI.Queries
{
    //Querie class for User
    public class QueriesServiceUser : Controller, IQueriesService<User>
    {
        private readonly WebStoreContext _context;
        public QueriesServiceUser(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
        public User GetSingle(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public IEnumerable<User> GetGroup(string str)
        {
            IEnumerable<User> users = _context.Users.Where(x => x.Role == str);
            return users.ToList();
        }
    }
}
