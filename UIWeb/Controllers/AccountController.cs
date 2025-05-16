using System.Threading.Tasks;
using Core.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UIWeb.Models;

namespace UIWeb.Controllers
{
  public class AccountController : Controller
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
        IdentityUser user = await _userManager.FindByNameAsync(model.Username);
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

    public IActionResult Register()
    {
      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm] RegisterDto model)
    {
      var user = new IdentityUser // Mapping
      {
        UserName = model.Username,
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
  }
}