using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace UIWeb.Controllers
{
  public class PostController : Controller
  {
    private readonly RepositoryContext _context;

    public PostController(RepositoryContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      var model = _context.Posts.ToList();
      return View(model);
    }
    public IActionResult Get(int id)
    {
      Post post = _context.Posts.First(p => p.Id.Equals(id));
      return View(post);
    }
  }
}