using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace UIWeb.Controllers
{
  public class CategoryController : Controller
  {
    //Dependency Injection
    private readonly IRepositoryManager _manager;

    // Constructor
    public CategoryController(IRepositoryManager manager)
    {
      _manager = manager;
    }

    // Views
    public IActionResult Index()
    {
      var model = _manager.Category.FindAll(false);
      return View(model);
    }
  }
}