using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPI.Models;

namespace WebStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        WebStoreContext db;
        UserModel um = new UserModel();
        //Initialization databse and paste start products, users
        public UsersController(WebStoreContext context)
        {
            this.db = context;
            DBInit.Init(context);
        }

        //Get list of users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Users);
        }

        //Get single user
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        //Add new user
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            um.Post(db, user);
            return Ok(user);
        }

        //Change user
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null)
                return BadRequest();
            if (!db.Users.Any(x => x.Id == user.Id))
                return NotFound();

            um.Put(db, user);
            return Ok(user);
        }

        //Delete user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();

            um.Delete(db, user);
            return Ok(user);
        }
    }
}