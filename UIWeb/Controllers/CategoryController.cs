using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Controllers
{
  public class CategoryController : Controller
  {
    //Dependency Injection
    private readonly IServiceManager _manager;

    // Constructor
    public CategoryController(IServiceManager manager)
    {
      _manager = manager;
    }

    // Views
    public IActionResult Index()
    {
      var model = _manager.CategoryService.GetAllCategories(false);
      return View(model);
    }
  }
}