using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebStoreAPI.Models;

namespace WebStoreAPI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }
    }
}