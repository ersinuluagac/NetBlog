using Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.UnitOfWork;

namespace UIWeb.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class UserController : Controller
  {
    private readonly IServiceManager _manager;

    public UserController(IServiceManager manager)
    {
      _manager = manager;
    }

    public SelectList GetAllRoles()
    {
      return new SelectList(_manager.AuthService.Roles);
    }
    public async Task<IActionResult> Index()
    {
      ViewBag.Roles = GetAllRoles();
      return View(await _manager.AuthService.GetAllUsersWithRole());
    }

    public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
    {
      var user = await _manager.AuthService.GetOneUserForUpdate(id);
      return View(user);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
    {
      if (ModelState.IsValid)
      {
        await _manager.AuthService.Update(userDto);
        return RedirectToAction("Index");
      }
      return View();
    }
  }
}