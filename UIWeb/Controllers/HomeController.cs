using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
