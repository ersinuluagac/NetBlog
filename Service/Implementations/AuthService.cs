using System.Threading.Tasks;
using Core.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    public async Task<IEnumerable<UserWithRoleDto>> GetAllUsersWithRole()
    {
      var users = _userManager.Users;
      var userWithRoleList = new List<UserWithRoleDto>();
      foreach (var user in users)
      {
        var roles = await _userManager.GetRolesAsync(user);
        userWithRoleList.Add(new UserWithRoleDto
        {
          Id = user.Id,
          Username = user.UserName,
          Email = user.Email,
          Role = roles.FirstOrDefault()
        });
      }
      return userWithRoleList;
    }
  }
}