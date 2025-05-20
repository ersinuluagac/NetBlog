using System.Security.Claims;
using Core.Dtos;
using Core.Models;
using Core.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.UnitOfWork;
using UIWeb.Models;

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
    public IActionResult Index(PostRequestParameters p)
    {
      var posts = _manager.PostService.GetAllPostsWithDetails(p);
      var pagination = new Pagination()
      {
        CurrentPage = p.PageNumber,
        ItemsPerPage = p.PageSize,
        TotalItems = _manager.PostService.GetAllPosts(false).Count()
      };
      return View(new PostListViewModel()
      {
        Posts = posts,
        Pagination = pagination
      });
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
    public async Task<IActionResult> Create([FromForm] PostDtoForCreation postDto, IFormFile file)
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
        postDto.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

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
    public async Task<IActionResult> Update([FromForm] PostDtoForUpdate postDto, IFormFile file)
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

    public IActionResult Delete(int id)
    {
      _manager.PostService.DeleteOnePost(id);
      return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddComment([FromForm] CommentDto commentDto)
    {
      if (ModelState.IsValid)
      {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        commentDto.UserId = userId;
        _manager.CommentService.CreateComment(commentDto);
        return RedirectToAction("Get", new { id = commentDto.PostId });
      }
      return View("Get", _manager.PostService.GetOnePost(commentDto.PostId, false));
    }
    [HttpPost("{postId}")]
    [ValidateAntiForgeryToken]
    public IActionResult ToggleLike([FromRoute] int postId)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (string.IsNullOrEmpty(userId))
        return Unauthorized();
      _manager.LikeService.ToggleLike(postId, userId);
      return RedirectToAction("Get", new { id = postId });
    }
  }
}