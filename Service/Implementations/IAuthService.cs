using Microsoft.AspNetCore.Identity;
using Service.Interfaces;

namespace Service.Implementations
{
  public class AuthService : IAuthService
  {
    // DI
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    // CTOR
    public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
      _roleManager = roleManager;
      _userManager = userManager;
    }

    public IEnumerable<IdentityRole> Roles =>
      _roleManager.Roles;

    public IEnumerable<IdentityUser> GetAllUsers()
    {
      return _userManager.Users.ToList();
    }
  }
}