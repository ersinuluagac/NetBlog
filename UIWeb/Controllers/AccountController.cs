using System.Security.Claims;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.UnitOfWork;
using UIWeb.Models;

namespace UIWeb.Controllers
{
  public class AccountController : Controller
  {
    private readonly IServiceManager _manager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(IServiceManager manager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _manager = manager;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public IActionResult SignIn([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
    {
      return View(new SignInModel()
      {
        ReturnUrl = returnUrl
      });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn([FromForm] SignInModel model)
    {
      if (ModelState.IsValid)
      {
        ApplicationUser user = await _userManager.FindByNameAsync(model.Username);
        if (user is not null)
        {
          await _signInManager.SignOutAsync();
          // Oturum açma
          if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
          {
            return Redirect(model?.ReturnUrl ?? "/");
          }
        }
        ModelState.AddModelError("Error", "KUllanıcı adı veya parola geçersin!");
      }
      return View();
    }

    public async Task<IActionResult> SignOut([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
    {
      await _signInManager.SignOutAsync();
      return Redirect(returnUrl);
    }

    public IActionResult SignUp()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp([FromForm] UserDtoForCreation userDto)
    {
      var result = await _manager.AuthService.CreateUser(userDto);
      return result.Succeeded
        ? RedirectToAction("SignIn", new { ReturnUrl = "/" })
        : View();
    }

    public async Task<IActionResult> Profile(string? id = null)
    {
      if (string.IsNullOrEmpty(id))
      {
        id = User.FindFirstValue(ClaimTypes.NameIdentifier);
      }
      var user = await _userManager.Users
          .Include(u => u.Posts).ThenInclude(p => p.Category)
          .Include(u => u.Comments)
          .Include(u => u.Likes)
          .FirstOrDefaultAsync(u => u.Id == id);

      if (user != null)
        return View(user);
      return NotFound();
    }

    public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
    {
      return View(new ResetPasswordDto()
      {
        UserName = id
      });
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
    {
      if (!ModelState.IsValid)
        return View(model);
      try
      {
        var result = await _manager.AuthService.ResetPassword(model);
        if (result.Succeeded)
          return RedirectToAction("Profile");
        else
        {
          foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);
        }
      }
      catch (Exception ex)
      {
        ModelState.AddModelError(string.Empty, ex.Message);
      }
      return View(model);
    }
  }
}