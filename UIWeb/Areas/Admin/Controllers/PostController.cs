using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Areas.Admin.Controllers
{
  [Area("Admin")] // Controller için area belirteci
  [Authorize(Roles = "Admin, Editor")]

  public class PostController : Controller
  {
    // Dependency Injection
    private readonly IServiceManager _manager;

    // Constructor
    public PostController(IServiceManager manager)
    {
      _manager = manager;
    }

    // Views
    public IActionResult Index()
    {
      var model = _manager.PostService.GetAllPosts(false);
      return View(model);
    }

    public IActionResult Delete([FromRoute(Name = "id")] int id)
    {
      _manager.PostService.DeleteOnePost(id);
      return RedirectToAction("Index");
    }
  }
}