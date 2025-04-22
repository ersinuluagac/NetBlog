using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
  [Area("Admin")] // Controller için area belirteci
  public class DashboardController : Controller
  {
    // Views
    public IActionResult Index()
    {
      return View();
    }
  }
}