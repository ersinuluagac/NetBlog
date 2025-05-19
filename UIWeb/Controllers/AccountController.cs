using System.Security.Claims;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIWeb.Models;

namespace UIWeb.Controllers
{
  public class AccountController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
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
    public async Task<IActionResult> SignUp([FromForm] UserDto model)
    {
      var user = new ApplicationUser // Mapping
      {
        UserName = model.UserName,
        Email = model.Email,
      };
      var result = await _userManager // Parola ile kullanıcı yarat
        .CreateAsync(user, model.Password);

      if (result.Succeeded) // Başarılı ise
      {
        var roleResult = await _userManager
          .AddToRoleAsync(user, "User"); // Role olarak "User" ata.
        if (roleResult.Succeeded) // Role atama başarılı ise
        {
          return RedirectToAction("SignIn", new { ReturnUrl = "/" }); // Giriş sayfasına yönlendir.
        }
      }
      else
      {
        foreach (var err in result.Errors) // Başarısız ise
        {
          ModelState.AddModelError("", err.Description);
        }
      }
      return View();
    }

    public async Task<IActionResult> Profile()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _userManager.Users
        .Include(u => u.Posts).ThenInclude(p => p.Category)
        .Include(u => u.Comments)
        .Include(u => u.Likes)
        .FirstOrDefaultAsync(u => u.Id.Equals(userId));
      if (user is not null)
        return View(user);
      return View();
    }
  }
}