using Core.Dtos;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    // SelectList
    private SelectList GetCategories()
    {
      return new SelectList(_manager.CategoryService.GetAllCategories(false), "Id", "Name", "1");
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
      ViewBag.Categories = GetCategories();
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] PostDto postDto, IFormFile file)
    {
      if (ModelState.IsValid)
      {
        //dosyalama işlemleri
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
          await file.CopyToAsync(stream);
        }
        postDto.ImageUrl = String.Concat("/images/", file.FileName);

        _manager.PostService.CreateOnePost(postDto);
        return RedirectToAction("Index");
      }
      return View();
    }

    public IActionResult Update([FromRoute(Name = "id")] int id)
    {
      ViewBag.Categories = GetCategories();
      var model = _manager.PostService.GetOnePostForUpdate(id, false);
      return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] PostDto postDto, IFormFile file)
    {
      ViewBag.Categories = GetCategories();

      if (ModelState.IsValid)
      {
        //dosyalama işlemleri
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
        using (var stream = new FileStream(path, FileMode.Create))
        {
          await file.CopyToAsync(stream);
        }
        postDto.ImageUrl = String.Concat("/images/", file.FileName);

        _manager.PostService.UpdateOnePost(postDto);
        return RedirectToAction("Index");
      }
      return View(postDto);
    }
  }
}