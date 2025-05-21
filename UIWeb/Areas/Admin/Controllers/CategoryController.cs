using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Areas.Admin.Controllers
{
  [Area("Admin")] // Controller için area belirteci
  [Authorize(Roles = "Admin, Editor")]
  public class CategoryController : Controller
  {
    private readonly IServiceManager _manager;

    public CategoryController(IServiceManager manager)
    {
      _manager = manager;
    }

    // Views
    public IActionResult Index()
    {
      return View(_manager.CategoryService.GetAllCategories(false));
    }
  }
}