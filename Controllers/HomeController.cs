using Microsoft.AspNetCore.Mvc;

namespace YummyMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
