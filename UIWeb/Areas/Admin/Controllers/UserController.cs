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
  }
}