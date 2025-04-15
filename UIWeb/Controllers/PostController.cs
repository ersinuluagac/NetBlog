using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace UIWeb.Controllers
{
  public class PostController : Controller
  {
    //Dependency Injection
    private readonly IRepositoryManager _manager;

    // Constructor
    public PostController(IRepositoryManager manager)
    {
      _manager = manager;
    }

    // Views
    public IActionResult Index()
    {
      var model = _manager.Post.GetAllPosts(false);
      return View(model);
    }
    public IActionResult Get(int id)
    {
      var model = _manager.Post.GetOnePost(id, false);
      return View(model);
    }
  }
}