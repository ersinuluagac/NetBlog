using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;

namespace UIWeb.Controllers
{
  public class PostController : Controller
  {
    //Dependency Injection
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
    public IActionResult Get([FromRoute(Name = "id")] int id)
    {
      var model = _manager.PostService.GetOnePost(id, false);
      return View(model);
    }
    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] Post post)
    {
      if (ModelState.IsValid)
      {
        _manager.PostService.CreatePost(post);
        return RedirectToAction("Index");
      }
      return View();
    }
  }
}