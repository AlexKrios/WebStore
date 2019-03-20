using Microsoft.AspNetCore.Mvc;

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