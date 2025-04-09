using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;

namespace UIWeb.Controllers
{
  public class PostController : Controller
  {
    private readonly IRepositoryManager _manager;

    public PostController(IRepositoryManager manager)
    {
      _manager = manager;
    }

    public IActionResult Index()
    {
      var model = _manager.Post.GetAllPosts(false);
      return View(model);
    }
    public IActionResult Get(int id)
    {
      // Post post = _manager.Posts.First(p => p.Id.Equals(id));
      return View();
    }
  }
}