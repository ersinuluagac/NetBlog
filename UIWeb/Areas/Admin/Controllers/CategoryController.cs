using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
  [Area("Admin")] // Controller için area belirteci
  public class CategoryController : Controller
  {
    // Views
    public IActionResult Index()
    {
      return View();
    }
  }
}