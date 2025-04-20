using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Components
{
  public class CategoriesMenuViewComponent : ViewComponent
  {
    // DI
    private readonly IServiceManager _manager;

    // Constructor
    public CategoriesMenuViewComponent(IServiceManager manager)
    {
      _manager = manager;
    }

    // ViewComponent
    public IViewComponentResult Invoke() // Kategori menüsünü döner
    {
      var categories = _manager.CategoryService.GetAllCategories(false);
      return View(categories);
    }
  }
}