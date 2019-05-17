using DataLibrary;
using Microsoft.EntityFrameworkCore;

namespace WebStoreAPI
{
    public class UserLogin
    {
        private readonly WebStoreContext _context;

        public UserLogin(WebStoreContext context)
        {
            _context = context;
        }

        public bool DataCheck(string name, string pass)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Name.Equals(name));

            return user.Result != null && user.Result.Password.Equals(pass);
        }
    }
}
