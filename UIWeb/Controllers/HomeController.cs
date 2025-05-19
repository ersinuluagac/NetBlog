using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Controllers
{
    public class HomeController : Controller
    {
        //Dependency Injection
        private readonly IServiceManager _manager;

        // Constructor
        public HomeController(IServiceManager manager)
        {
            _manager = manager;
        }

        // Views
        public IActionResult Index()
        {
            return View();
        }
    }
}
