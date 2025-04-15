using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    public class HomeController : Controller
    {
        // Views
        public IActionResult Index()
        {
            return View();
        }
    }
}
