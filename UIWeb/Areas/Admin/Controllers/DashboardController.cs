using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
  [Area("Admin")] // Controller için area belirteci
  [Authorize(Roles = "Admin, Editor")]

  public class DashboardController : Controller
  {
    // Views
    public IActionResult Index()
    {
      return View();
    }
  }
}