using Microsoft.AspNetCore.Mvc;
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

    public IActionResult Index()
    {
      return View(_manager.AuthService.GetAllUsers());
    }
  }
}