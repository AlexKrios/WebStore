using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebStoreAPI.Controllers
{
    public class AdminController : Controller
    {
        [Route("[controller]/products")]
        public IActionResult Products()
        {
            return View();
        }
    }
}